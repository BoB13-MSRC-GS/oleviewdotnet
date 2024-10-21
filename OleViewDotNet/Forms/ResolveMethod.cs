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

namespace OleViewDotNet.Forms
{
    internal class ResolveMethod:Form
    {

        public static String[] banList = 
        {
            "C:\\WINDOWS\\SYSTEM32\\MSASN1.dll",
            "C:\\WINDOWS\\SYSTEM32\\dxcore.dll",
            "C:\\WINDOWS\\SYSTEM32\\twinapi.appcore.dll",
            "C:\\WINDOWS\\SYSTEM32\\wevtapi.dll",
            "C:\\WINDOWS\\SYSTEM32\\winsta.dll",
            "C:\\WINDOWS\\System32\\WINSTA.dll",
            "C:\\WINDOWS\\System32\\profapi.dll",
            "C:\\WINDOWS\\system32\\MSASN1.dll",
            "C:\\WINDOWS\\system32\\ncryptprov.dll",
            "C:\\Windows\\System32\\Microsoft.Bluetooth.Proxy.dll",
            "C:\\Windows\\System32\\SspiCli.dll",
            "C:\\Windows\\System32\\Windows.Security.Authentication.OnlineId.dll",
            "C:\\Windows\\System32\\XmlLite.dll",
            "C:\\Windows\\System32\\msxml6.dll",
            "C:\\Windows\\System32\\vaultcli.dll",
            "c:\\windows\\system32\\BrokerLib.dll",
            "c:\\windows\\system32\\PROPSYS.dll",
            "c:\\windows\\system32\\WMICLNT.dll",
            "c:\\windows\\system32\\fwbase.dll",
            "c:\\windows\\system32\\wlanapi.dll",
            "C:\\WINDOWS\\SYSTEM32\\IPHLPAPI.DLL",
            "C:\\WINDOWS\\SYSTEM32\\bi.dll",
            "C:\\WINDOWS\\SYSTEM32\\capauthz.dll",
            "C:\\WINDOWS\\System32\\CRYPTBASE.DLL",
            "C:\\WINDOWS\\System32\\NTASN1.dll",
            "C:\\WINDOWS\\System32\\SETUPAPI.dll",
            "C:\\WINDOWS\\System32\\SHLWAPI.dll",
            "C:\\WINDOWS\\System32\\SspiCli.dll",
            "C:\\WINDOWS\\System32\\fwpuclnt.dll",
            "C:\\WINDOWS\\System32\\ncrypt.dll",
            "C:\\WINDOWS\\System32\\netutils.dll",
            "C:\\WINDOWS\\System32\\sspicli.dll",
            "C:\\WINDOWS\\System32\\wkscli.dll",
            "C:\\Windows\\System32\\AppXDeploymentClient.dll",
            "c:\\windows\\system32\\WppRecorderUM.dll",
            "c:\\windows\\system32\\netutils.dll",
            "C:\\WINDOWS\\SYSTEM32\\netjoin.dll",
            "C:\\WINDOWS\\SYSTEM32\\netutils.dll",
            "C:\\WINDOWS\\System32\\CRYPTBASE.dll",
            "C:\\WINDOWS\\System32\\DPAPI.DLL",
            "C:\\WINDOWS\\System32\\SHCORE.dll",
            "C:\\WINDOWS\\System32\\SHELL32.dll",
            "C:\\WINDOWS\\System32\\netprofm.dll",
            "C:\\WINDOWS\\system32\\execmodelproxy.dll",
            "C:\\Windows\\System32\\Windows.Networking.Connectivity.dll",
            "C:\\Windows\\System32\\Windows.Web.dll",
            "C:\\Windows\\System32\\iertutil.dll",
            "C:\\Windows\\System32\\msvcp110_win.dll",
            "C:\\Windows\\System32\\netutils.dll",
            "C:\\Windows\\System32\\srvcli.dll",
            "C:\\Windows\\System32\\usermgrproxy.dll",
            "c:\\windows\\system32\\DNSAPI.dll",
            "c:\\windows\\system32\\DSROLE.dll",
            "c:\\windows\\system32\\MobileNetworking.dll",
            "c:\\windows\\system32\\SYSNTFY.dll",
            "c:\\windows\\system32\\WINSTA.dll",
            "c:\\windows\\system32\\WTSAPI32.dll",
            "c:\\windows\\system32\\fwpuclnt.dll",
            "c:\\windows\\system32\\AUTHZ.dll",
            "c:\\windows\\system32\\NTASN1.dll",
            "c:\\windows\\system32\\ncrypt.dll",
            "C:\\WINDOWS\\SYSTEM32\\wlanapi.dll",
            "C:\\WINDOWS\\System32\\DEVOBJ.dll",
            "C:\\WINDOWS\\system32\\ncryptsslp.dll",
            "C:\\WINDOWS\\system32\\schannel.DLL",
            "C:\\WINDOWS\\system32\\sspicli.dll",
            "C:\\Windows\\System32\\taskschd.dll",
            "c:\\windows\\system32\\WINNSI.DLL",
            "C:\\WINDOWS\\SYSTEM32\\SspiCli.dll",
            "C:\\WINDOWS\\SYSTEM32\\profapi.dll",
            "C:\\WINDOWS\\System32\\IMM32.DLL",
            "C:\\WINDOWS\\System32\\coml2.dll",
            "C:\\Windows\\System32\\CapabilityAccessManagerClient.dll",
            "C:\\Windows\\System32\\Windows.StateRepositoryPS.dll",
            "C:\\WINDOWS\\SYSTEM32\\windows.staterepositoryclient.dll",
            "C:\\WINDOWS\\System32\\WINTRUST.dll",
            "C:\\WINDOWS\\system32\\CRYPTBASE.dll",
            "C:\\Windows\\System32\\WinTypes.dll",
            "c:\\windows\\system32\\webio.dll",
            "C:\\WINDOWS\\SYSTEM32\\MobileNetworking.dll",
            "C:\\WINDOWS\\System32\\ADVAPI32.dll",
            "C:\\Windows\\System32\\twinapi.appcore.dll",
            "c:\\windows\\system32\\UMPDC.dll",
            "C:\\WINDOWS\\SYSTEM32\\cryptsp.dll",
            "C:\\Windows\\System32\\OneCoreCommonProxyStub.dll",
            "c:\\windows\\system32\\WINHTTP.dll",
            "c:\\windows\\system32\\profapi.dll",
            "C:\\WINDOWS\\System32\\npmproxy.dll",
            "c:\\windows\\system32\\SspiCli.dll",
            "c:\\windows\\system32\\msvcp110_win.dll",
            "C:\\WINDOWS\\System32\\MSASN1.dll",
            "c:\\windows\\system32\\DEVOBJ.dll",
            "C:\\WINDOWS\\SYSTEM32\\WINSTA.dll",
            "C:\\Windows\\System32\\OneCoreUAPCommonProxyStub.dll",
            "C:\\Windows\\System32\\rasadhlp.dll",
            "C:\\WINDOWS\\SYSTEM32\\windows.staterepositorycore.dll",
            "C:\\WINDOWS\\System32\\shlwapi.dll",
            "C:\\WINDOWS\\system32\\rsaenh.dll",
            "c:\\windows\\system32\\USERENV.dll",
            "C:\\WINDOWS\\SYSTEM32\\DNSAPI.dll",
            "C:\\WINDOWS\\SYSTEM32\\WINNSI.DLL",
            "C:\\WINDOWS\\SYSTEM32\\policymanager.dll",
            "C:\\WINDOWS\\SYSTEM32\\rmclient.dll",
            "C:\\WINDOWS\\SYSTEM32\\windows.storage.dll",
            "C:\\WINDOWS\\SYSTEM32\\dhcpcsvc.DLL",
            "C:\\WINDOWS\\SYSTEM32\\dhcpcsvc6.DLL",
            "C:\\WINDOWS\\SYSTEM32\\gpapi.dll",
            "C:\\WINDOWS\\SYSTEM32\\usermgrcli.dll",
            "C:\\WINDOWS\\SYSTEM32\\wtsapi32.dll",
            "C:\\WINDOWS\\SYSTEM32\\wintypes.dll",
            "C:\\WINDOWS\\System32\\ole32.dll",
            "c:\\windows\\system32\\IPHLPAPI.DLL",
            "C:\\WINDOWS\\SYSTEM32\\UMPDC.dll",
            "C:\\WINDOWS\\SYSTEM32\\ntmarta.dll",
            "C:\\WINDOWS\\system32\\mswsock.dll",
            "C:\\WINDOWS\\System32\\svchost.exe",
            "C:\\WINDOWS\\System32\\CRYPT32.dll",
            "C:\\WINDOWS\\SYSTEM32\\powrprof.dll",
            "C:\\WINDOWS\\System32\\NSI.dll",
            "C:\\WINDOWS\\SYSTEM32\\cfgmgr32.dll",
            "C:\\WINDOWS\\System32\\WS2_32.dll",
            "C:\\WINDOWS\\System32\\shcore.dll",
            "C:\\WINDOWS\\System32\\advapi32.dll",
            "C:\\WINDOWS\\system32\\svchost.exe",
            "C:\\WINDOWS\\System32\\OLEAUT32.dll",
            "C:\\WINDOWS\\System32\\clbcatq.dll",
            "C:\\WINDOWS\\System32\\user32.dll",
            "C:\\WINDOWS\\System32\\GDI32.dll",
            "C:\\WINDOWS\\System32\\gdi32full.dll",
            "C:\\WINDOWS\\System32\\win32u.dll",
            "C:\\WINDOWS\\SYSTEM32\\kernel.appcore.dll",
            "C:\\WINDOWS\\System32\\bcryptPrimitives.dll",
            "C:\\WINDOWS\\SYSTEM32\\ntdll.dll",
            "C:\\WINDOWS\\System32\\KERNEL32.DLL",
            "C:\\WINDOWS\\System32\\KERNELBASE.dll",
            "C:\\WINDOWS\\System32\\RPCRT4.dll",
            "C:\\WINDOWS\\System32\\bcrypt.dll",
            "C:\\WINDOWS\\System32\\combase.dll",
            "C:\\WINDOWS\\System32\\msvcp_win.dll",
            "C:\\WINDOWS\\System32\\msvcrt.dll",
            "C:\\WINDOWS\\System32\\sechost.dll",
            "C:\\WINDOWS\\System32\\ucrtbase.dll",
            "C:\\WINDOWS\\System32\\d3d11.dll",
            "C:\\WINDOWS\\System32\\d2d1.dll"
        };

        public static String GetIDAT()
        {
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

                            if (valueData is string stringValue && stringValue.Contains("Hex-Rays SA"))
                            {
                                Console.WriteLine($"Found 'Hex-Rays SA' in: {valueName}");
                                Console.WriteLine($"Data: {stringValue}");
                                String[] parts = valueName.Split('\\');
                                String fileName = String.Join("\\", parts, 0, parts.Length - 1)+"\\idat64.exe";
                                Console.WriteLine("IDAT Path : "+fileName);
                                if (File.Exists(fileName)) return fileName;
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
            MessageBox.Show("Failed to find idat64.exe.");
            return null;
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

        public static void GenerateAsmFile(String binaryPath)
        {
            String binaryName = Path.GetFileName(binaryPath);
            if (File.Exists($"DLLs\\{binaryName}" + ".asm")) return;
            CopyDLL(binaryPath);
            Console.WriteLine("GenerateAsmFile() Start." + binaryName);
            Process process = new Process();
            process.StartInfo.FileName = GetIDAT();
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
                            String[] parts = line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].
                                Split(new String[] { "::" }, StringSplitOptions.None);
                            String className = String.Join("::", parts, 0, parts.Length - 1);
                            String methodName = line.Split(new String[] { "dq offset ?" }, StringSplitOptions.None)[1]
                                .Split('@')[0];
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
                                int pCnt1 = CountParameters(line.Split(new String[] {" ; "}, StringSplitOptions.None)[1].Trim());
                                int pCnt2 = CountParameters(methodsFromIdl[idlIndex].Trim());
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
                                String[] parts = line.Split(new String[] { " ; " }, StringSplitOptions.None)[1].
                                    Split(new String[] { "::" }, StringSplitOptions.None);
                                String className = String.Join("::", parts, 0, parts.Length - 1);
                                String methodName = line.Split(new String[] { "dq offset ?" }, StringSplitOptions.None)[1]
                                    .Split('@')[0];
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
