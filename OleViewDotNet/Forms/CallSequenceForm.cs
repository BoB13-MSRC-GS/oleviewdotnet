using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OleViewDotNet.Forms
{
    public partial class CallSequenceForm : Form
    {
        Dictionary<String, List<String>> interfaces = null;
        List<List<String>> sequence;
        public CallSequenceForm()
        {
            String[] fileNames = Directory.GetFiles("interfaces\\sequence");

            if (fileNames.Length == 0)
            {
                MessageBox.Show("View Proxy Library First.");
                return;
            }
            InitializeComponent();
            if (interfaces == null)
            {
                interfaces = new Dictionary<String, List<String>>();
                foreach (String file in fileNames)
                {
                    String idl = null;
                    using (StreamReader sr = new StreamReader(file))
                    {
                        idl = sr.ReadToEnd();
                    }
                    if (Path.GetFileName(file) == "now")
                    {
                        textBox1.Text = idl;
                        continue;
                    }
                    String[] lines = idl.Split('\n');
                    String interfaceName = null;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        String line = lines[i].Trim();
                        if (line.StartsWith("interface"))
                        {
                            Console.WriteLine("Get Interface Name : " + line);
                            interfaceName = line.Split(' ')[1];
                            break;
                        }
                    }
                    comboBox1.Items.Add(interfaceName);
                    Console.WriteLine("interfaceName : " + interfaceName);
                    interfaces[interfaceName] = new List<String>();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        String line = lines[i].Trim();
                        if (line.StartsWith("HRESULT"))
                        {
                            List<String> parameters = GetParameters(line);
                            for (int j = 1; j < parameters.Count; j++)
                            {
                                String[] param = parameters[j].Trim().Split(' ');
                                Console.Write("Now Processing : ");
                                foreach (String p in param) Console.Write(p + " ");
                                Console.WriteLine();
                                if (param[0].Contains("out") && param[param.Length - 2].StartsWith("I"))
                                {
                                    Console.WriteLine($"Gotcha : {interfaceName} -> {param[param.Length - 2]}");
                                    param[param.Length - 2] = param[param.Length - 2].Replace("*", "");
                                    if (!interfaces.Keys.Contains(param[param.Length-2]))
                                    {
                                        interfaces[param[param.Length - 2]] = new List<string>();
                                    }
                                    interfaces[interfaceName].Add(param[param.Length - 2]);
                                }
                            }
                        }
                    }
                }
                foreach (String i in interfaces.Keys)
                {
                    Console.Write(i + " : ");
                    foreach (String j in interfaces[i])
                    {
                        Console.Write(j + " ");
                    }
                    Console.WriteLine();
                }
            }
            
        }

        public List<String> GetParameters(string functionDeclaration)
        {
            Console.WriteLine($"CountParameters() Processing : {functionDeclaration}");
            if (functionDeclaration.Trim().EndsWith("(void)"))
                return new List<string>();

            // 템플릿 인자 제거
            string functionDefinition = Regex.Replace(functionDeclaration, @"<.*?>", "");
            Console.WriteLine($"CountParameters() functionDefinition : {functionDefinition}");
            // 함수 이름과 파라미터 부분 추출 (특수 소멸자 케이스 포함)
            Match match = Regex.Match(functionDefinition, @"([\w:~]+|`.*?')\s*\((.*?)\)\s*(?:const)?(?:override)?;?$");
            if (!match.Success)
                return new List<string>();

            string functionName = match.Groups[1].Value;
            string parameters = match.Groups[2].Value;
            
            // 파라미터가 없는 경우
            if (string.IsNullOrWhiteSpace(parameters))
                return new List<string>();
            Console.WriteLine($"CountParameters() parameters : {parameters}");
            // 대괄호 내부의 콤마 임시 대체
            parameters = Regex.Replace(parameters, @"\[([^\]]*)\]", m => m.Groups[0].Value.Replace(",", "<COMMA>"));

            // 템플릿 인자 내부의 콤마 임시 대체
            parameters = Regex.Replace(parameters, @"<([^>]*)>", m => m.Groups[0].Value.Replace(",", "<COMMA>"));

            // 파라미터 분리
            var paramList = parameters.Split(',').Select(p => p.Replace("<COMMA>", ",")).ToList();
            foreach (var param in paramList) { Console.WriteLine("ParamList : " + param); }
            paramList.Insert(0, functionName);
            // 빈 파라미터 제거 및 개수 반환
            return paramList;
        }
        public void GetSequence(String baseInterface)
        {
            if (!interfaces.Keys.Contains(baseInterface))
            {
                textBox2.Text = $"No Interface \"{baseInterface}\" in Proxy.";
                return;
            }
            sequence = new List<List<string>>();
            for (int i = 0; i < interfaces[baseInterface].Count; i++)
            {
                List<String> nowSequence = new List<String>();
                nowSequence.Add(baseInterface);
                Search(nowSequence, interfaces[baseInterface][i]);
            }
            if (sequence.Count == 0)
            {
                textBox2.Text = "No Results.";
                return;
            }
            textBox2.Text = "";
            foreach(List<String> now in sequence)
            {
                textBox2.Text += String.Join(" → ", now) + "\r\n";
            }
        }

        public void Search(List<String> nowSequence, String next)
        {
            
            if (interfaces[next].Count == 0) {
                nowSequence.Add(next);
                bool flag = true;
                foreach (List<String> now in sequence)
                {
                    if (now.SequenceEqual(nowSequence))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) sequence.Add(nowSequence);
                return;
            }

            if (nowSequence.Contains(next))
            {
                bool flag = true;
                foreach(List<String> now in sequence)
                {
                    if (now.SequenceEqual(nowSequence))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) sequence.Add(nowSequence);
                return;
            }
            nowSequence.Add(next);
            foreach (String now in interfaces[next])
            {
                List<String> newSequence = nowSequence.ToList();
                Search(newSequence, now);
            }
            return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String interfaceName = this.comboBox1.Text;
            GetSequence(interfaceName);
        }
    }
}
