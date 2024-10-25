using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace OleViewDotNet.Forms
{
    internal class ResolveMethod
    {
        public static String IDAPath = null;
        public static List<String> banList = null;

        public static String GetIDAT()
        {

            if (File.Exists("IDAPath"))
            {
                using (StreamReader reader = new StreamReader("IDAPath"))
                {
                    IDAPath = reader.ReadToEnd();
                }
                return IDAPath;
            }

            string regKey = "Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache";
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(regKey))
                {
                    if (key != null)
                    {
                        foreach (string valueName in key.GetValueNames())
                        {
                            object valueData = key.GetValue(valueName);
                            Console.WriteLine($"Now Searching : {valueName} {valueData}");
                            if (valueData is string stringValue && stringValue.Contains("Hex-Rays SA"))
                            {
                                Console.WriteLine($"Found 'Hex-Rays SA' in: {valueName}");
                                Console.WriteLine($"Data: {stringValue}");
                                String[] parts = valueName.Split('\\');
                                String fileName = String.Join("\\", parts, 0, parts.Length - 1)+"\\idat64.exe";
                                Console.WriteLine("IDAT Path : "+fileName);
                                if (File.Exists(fileName))
                                {
                                    IDAPath = fileName;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"GetIDAT(): Registry key {regKey} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetIDAT(): {ex.Message}");
            }

            if (IDAPath == null)
            {
                MessageBox.Show("Failed to find idat64.exe.");

                IDAPathForm iDAPathForm = new IDAPathForm();
                iDAPathForm.ShowDialog();
            }

            using (StreamWriter writer = new StreamWriter("IDAPath"))
            {
                writer.Write(IDAPath);
            }

            return IDAPath;
        }

        public static String GetBinaryPath(String serviceName)
        {
            String regKey = $"SYSTEM\\ControlSet001\\Services\\{serviceName}\\Parameters";
            object value = null;
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey))
                {
                    if (key != null)
                    {
                        value = key.GetValue("ServiceDLL");
                    }
                }
                if (value == null)
                {
                    regKey = $"SYSTEM\\ControlSet001\\Services\\{serviceName}";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey))
                    {
                        if (key != null)
                        {
                            value = key.GetValue("ServiceDLL");
                        }
                    }
                }
                if (value == null)
                {
                    regKey = $"SYSTEM\\ControlSet001\\Services\\{serviceName}";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey))
                    {
                        if (key != null)
                        {
                            value = key.GetValue("ImagePath");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetBinaryPath():"+ex.ToString());
            }

            if (value == null)
            {
                Console.WriteLine("Failed to get binary path.");
                return null;
            }
            else
            {
                String binaryName = value.ToString().ToLower();
                binaryName = binaryName.Replace("%systemroot%", "C:\\Windows");
                binaryName = binaryName.Replace("\"", "");
                binaryName = binaryName.Replace("%programfiles%", "C:\\Program Files");
                binaryName = binaryName.Replace("%windir%", "C:\\Windows");
                binaryName = binaryName.Replace("\n", "");

                String[] parts = binaryName.Split(' ');
                if (parts[parts.Length-1].EndsWith(".exe") || parts[parts.Length - 1].EndsWith(".dll"))
                {
                    binaryName = String.Join(" ", parts);
                }
                else
                {
                    binaryName = String.Join(" ", parts, 0, parts.Length - 1);
                }

                Console.WriteLine($"Binary Path : {binaryName}");
                return binaryName;
            }
        }


        public static void CopyDLL(String binaryPath)
        {
            if (!Directory.Exists("DLLs")) Directory.CreateDirectory("DLLs");
            String binaryName = Path.GetFileName(binaryPath);
            if (!File.Exists($"DLLs\\{binaryName}"))
            {
                
                File.Copy(binaryPath, $"DLLs\\{binaryName}");
            }
        }

        public static bool GenerateAsmFile(String binaryPath)
        {
            String binaryName = Path.GetFileName(binaryPath);
            if (File.Exists($"DLLs\\{binaryName}" + ".asm")) return true;
            CopyDLL(binaryPath);
            Console.WriteLine("GenerateAsmFile() Start. " + binaryName);
            Process process = new Process();
            if (IDAPath == null) process.StartInfo.FileName = GetIDAT();
            process.StartInfo.FileName = IDAPath;
            Console.WriteLine($"IDAT Path : {IDAPath}");
            //process.StartInfo.FileName = GetIDAT();
            //if (process.StartInfo.FileName == null) return false;
            process.StartInfo.Arguments = $"-A -B DLLs\\{binaryName}";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            try
            {
                process.Start();
                process.WaitForExit();
                int exitCode = process.ExitCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Failed to resolve interfaces.");
            }
            process.Dispose();
            Console.WriteLine("GenerateAsmFile() Done.");
            return true;
        }

        public static String GetInterfaceName(String idl)
        {
            String[] lines = idl.Split('\n');
            if (lines[0].StartsWith("["))
            {
                foreach (String line in lines)
                {
                    if (line.StartsWith("interface")) return line.Split(' ')[1];
                }
            }
            else
            {
                return lines[0].Split(' ')[2];
            }
            return null;
        }

        public static List<List<String>> GetMethodsFromIDA(String binaryPath, String idl)
        {
            
            List<List<String>> ret = new List<List<String>>();
            List<String> methodsFromIdl = new List<String>();
            String[] asmLines = null;
            String[] idlLines = idl.Split('\n');

            foreach (String line in idlLines)
            {
                if (line.Contains("HRESULT")) methodsFromIdl.Add(line);
            }

            String binaryName = Path.GetFileName(binaryPath);
            String interfaceName = GetInterfaceName(idl);
            if (!File.Exists($"DLLs\\{binaryName}.asm")) return ret;
            using (StreamReader reader = new StreamReader($"DLLs\\{binaryName}.asm"))
            {
                String asm = reader.ReadToEnd();
                
                if (!asm.Contains("QueryInterface"))
                {
                    using (StreamWriter writer = new StreamWriter("BanList", true))
                    {
                        writer.Write("\n"+binaryPath);
                    }
                }
                asmLines = asm.Split('\n');
            }
            int lineIndex = 0;
            while (true)
            {
                List<String> methods = new List<String> { "QueryInterface", "AddRef", "Release" };
                if (lineIndex >= asmLines.Length) break;
                String line = asmLines[lineIndex++];
                
                if (line.Contains($"`vftable'{{for `{interfaceName}'}}"))
                {
                    //Console.WriteLine("Got New vftable : "+line);
                    int nowIndex = lineIndex;
                    bool flag = false;
                    while (true)
                    {
                        line = asmLines[lineIndex++];
                        //Console.WriteLine(line);
                        if (line.Contains("?Release")) break;
                        if (lineIndex > nowIndex+8)
                        {
                            lineIndex = nowIndex;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine($"flag enabled. return to {nowIndex} from {lineIndex}.");
                        //lineIndex++;
                        continue;
                    }
                    while (true)
                    {
                        nowIndex = lineIndex;
                        line = asmLines[lineIndex++].Trim(' ');
                        if (line.Contains("?Release")) continue;
                        if (line.StartsWith("dq offset ??"))
                        {
                            break;
                        }
                        else if (line.StartsWith("dq offset ?"))
                        {
                            //Console.WriteLine(line);
                            String[] parts;
                            String className = "", methodName = "";
                            try
                            {
                                parts = line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].
                                    Split(new String[] { "::" }, StringSplitOptions.None);
                                className = String.Join("::", parts, 0, parts.Length - 1);
                                methodName = line.Split(new String[] { "dq offset ?" }, StringSplitOptions.None)[1].Split('@')[0];
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                                methodName = line.Split('?')[1].Split('@')[0];
                            }
                            methods.Add($"/*{className}*/{methodName}");
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (methods.Count >= 4 && (methods.Count - methodsFromIdl.Count - 3) >= 0 && (methods.Count - methodsFromIdl.Count - 3) <= 1)
                    {
                        ret.Add(methods);
                    }
                }
            }
            return ret;
        }

        public static List<List<String>> GetMethodsFromCandidates(String binaryPath, String idl)
        {

            List<List<String>> ret = new List<List<String>>();
            List<String> methodsFromIdl = new List<String>();
            String[] asmLines = null;
            String[] idlLines = idl.Split('\n');

            foreach (String line in idlLines)
            {
                if (line.Contains("HRESULT")) methodsFromIdl.Add(line);
            }

            String binaryName = Path.GetFileName(binaryPath);
            String interfaceName = GetInterfaceName(idl);
            if (!File.Exists($"DLLs\\{binaryName}.asm")) return ret;
            using (StreamReader reader = new StreamReader($"DLLs\\{binaryName}.asm"))
            {
                asmLines = reader.ReadToEnd().Split('\n');
            }

            int lineIndex = 0;
            while (true)
            {
                List<String> methods = new List<String> { "QueryInterface", "AddRef", "Release" };
                if (lineIndex >= asmLines.Length) break;
                String line = asmLines[lineIndex++];

                if (line.Contains($"`vftable'"))
                {
                    line = asmLines[lineIndex++];
                    if (line.Contains("QueryInterface"))
                    {
                        Console.WriteLine("Got New vftable : "+line);
                        int idlIndex = 0;
                        int diffCnt = 0;
                        int nowIndex = lineIndex;
                        int diffBase = 0;
                        bool flag = false;
                        while (true)
                        {
                            line = asmLines[lineIndex++];
                            //Console.WriteLine(line);
                            if (line.Contains("?Release")) break;
                            if (lineIndex > nowIndex + 8)
                            {
                                lineIndex = nowIndex;
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            //lineIndex++;
                            continue;
                        }
                        while (true)
                        {
                            nowIndex = lineIndex;
                            line = asmLines[lineIndex++].Trim(' ');
                            if (line.Contains("?Release")) continue;
                            if (line.StartsWith("dq offset ??"))
                            {
                                lineIndex = nowIndex;
                                break;
                            }
                            else if (line.StartsWith("dq offset ?"))
                            {
                                if (idlIndex == methodsFromIdl.Count)
                                {
                                    flag = true;
                                    break;
                                }
                                int pCnt1=0, pCnt2=0;
                                try
                                {
                                    pCnt2 = CountParameters(methodsFromIdl[idlIndex].Trim());
                                    pCnt1 = CountParameters(line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].Trim());
                                }
                                catch (IndexOutOfRangeException ex)
                                {
                                    pCnt1 = pCnt2;
                                }

                                if (pCnt1 != pCnt2)
                                {
                                    Console.WriteLine($"----------------different! {pCnt1} {pCnt2}");
                                    Console.WriteLine($"line : {line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].Trim(' ')}");
                                    Console.WriteLine($"methodsFromIdl : {methodsFromIdl[idlIndex].Trim(' ')}");
                                    if (methodsFromIdl.Count == 1)
                                    {
                                        flag = true;
                                        break;
                                    }
                                    diffCnt++;
                                    if (methodsFromIdl.Count < 10) diffBase = 1;
                                    else diffBase = methodsFromIdl.Count / 10;
                                    if (diffCnt > diffBase)
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                
                                Console.WriteLine($"--------------same! {pCnt1} {pCnt2} {line}");
                                String[] parts;
                                String className="", methodName="";
                                try
                                {
                                    parts = line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].
                                        Split(new String[] { "::" }, StringSplitOptions.None);
                                    className = String.Join("::", parts, 0, parts.Length - 1);
                                    methodName = line.Split(new String[] { "dq offset ?" }, StringSplitOptions.None)[1].Split('@')[0];
                                }
                                catch (IndexOutOfRangeException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    methodName = line.Split('?')[1].Split('@')[0];
                                }  
                                methods.Add($"/*{className}*/{methodName}");
                                idlIndex++;
                            }
                            else if (line.Contains("purecall"))
                            {
                                lineIndex = nowIndex;
                                break;
                            }
                            else
                            {
                                lineIndex = nowIndex;
                                break;
                            }
                        }
                        if (methods.Count - methodsFromIdl.Count - 3 > 1 || methods.Count - methodsFromIdl.Count - 3 < 0) flag = true;
                        if (methodsFromIdl.Count >= 4 && ((methods.Count - methodsFromIdl.Count - 3) >= 0 && (methods.Count - methodsFromIdl.Count - 3) <= 1)) flag = false;
                        if (methods.Count == 5 && methods[3].EndsWith("CreateInstance") && methods[4].EndsWith("LockServer")) flag = true;
                        if (!flag)
                        {
                            ret.Add(methods);
                        }
                    }
                }
            }
            return ret;
        }

        public static int CountParameters(string functionDeclaration)
        {
            Console.WriteLine($"CountParameters() Processing : {functionDeclaration}");
            if (functionDeclaration.Trim().EndsWith("(void)"))
                return 0;

            // 템플릿 인자 제거
            string functionDefinition = Regex.Replace(functionDeclaration, @"<.*?>", "");

            // 함수 이름과 파라미터 부분 추출 (특수 소멸자 케이스 포함)
            Match match = Regex.Match(functionDefinition, @"([\w:~]+|`.*?')\s*\((.*?)\)\s*(?:const)?(?:override)?;?$");
            if (!match.Success)
                return 0;

            string functionName = match.Groups[1].Value;
            string parameters = match.Groups[2].Value;

            // 파라미터가 없는 경우
            if (string.IsNullOrWhiteSpace(parameters))
                return 0;

            // 대괄호 내부의 콤마 임시 대체
            parameters = Regex.Replace(parameters, @"\[([^\]]*)\]", m => m.Groups[0].Value.Replace(",", "<COMMA>"));

            // 템플릿 인자 내부의 콤마 임시 대체
            parameters = Regex.Replace(parameters, @"<([^>]*)>", m => m.Groups[0].Value.Replace(",", "<COMMA>"));

            // 파라미터 분리
            var paramList = parameters.Split(',').Select(p => p.Replace("<COMMA>", ",")).ToList();

            // 빈 파라미터 제거 및 개수 반환
            return paramList.Count(p => !string.IsNullOrWhiteSpace(p));
        }

        public static String ConvertMethodName(String idl, List<String> methods)
        {
            if (methods.Count == 0) return idl + "\n";
            String result = "";
            int index = 3;
            String[] lines = idl.Split('\n');

            String funcStyle;

            if (lines[0][0] == '[')
            {
                funcStyle = "HRESULT Proc";
            }
            else
            {
                funcStyle = "__stdcall Proc";
            }
            foreach(String line in lines)
            {
                String now = line + "\n";
                if (line.Contains(funcStyle))
                {
                    if (index == methods.Count) continue;
                    now = line.Split(new String[] { " Proc" }, StringSplitOptions.None)[0] + " ";
                    now += methods[index++];
                    foreach(String tmp in line.Split('(').Skip(1).ToArray())
                    {
                        now += "(" + tmp;
                    }
                    now += "\n";
                }
                result += now;
            }
            return result;
        }
    }
}
