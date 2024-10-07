import winreg, subprocess, sys, shutil, os, re

def GetIDATPath(key_path):
    try:
        registry = winreg.ConnectRegistry(None, winreg.HKEY_CLASSES_ROOT)
        
        key = winreg.OpenKey(registry, key_path)
        
        i = 0
        while True:
            try:
                value_name, value_data, _ = winreg.EnumValue(key, i)
                if value_data == "Hex-Rays SA":
                    fileName = "".join(value_name.split("ida64.exe")[:-1])+"idat64.exe"
                    if not os.path.exists(fileName):
                        i+=1
                        continue
                    winreg.CloseKey(key)
                    return fileName
                i += 1
            except OSError:
                break
    except Exception as e:
        print(f"Error: {e}")
        fResult = open(RESULT_PATH, "w")
        ErrorExit(fResult, "IDA NOT FOUND!!!!")

def ReadInterfaceFile(filename):
    f = open(filename, "r")

def get_asembly(IDAT, BINARY):
    command = [
        IDAT,
        '-A',
        '-B',
        BINARY
    ]
    try:
        result = subprocess.run(command, check=True)
        return True
    except Exception as e:
        ErrorExit()

def ErrorExit(fResult=None, error=None):
    if fResult!=None:
        if error!=None: fResult.write(str(error))
        fResult.close()
    sys.exit(-1)

def GetBinaryName(path:str):
    return path.split("\\")[-1].split(" ")[0]

def GetInterfaceName(content):
    content = content.split("\n")
    if content[0].startswith("["):
        for i in range(len(content)):
            line = content[i]
            if line.startswith("interface"):
                return line.split(" ")[1]
    else:
        print(content[0].split(" : ")[0])
        return content[0].split(" : ")[0].split(") ")[1]

def GetInterfacesFromIDL(path):
    result = []
    fIdl = open(path, "r")
    fIdl.seek(0,2)
    end = fIdl.tell()
    fIdl.seek(0,0)
    line = fIdl.readline()
    fIdl.seek(0,0)
    if line.startswith("class"):
        while True:
            if fIdl.tell()==end:break
            now = ""
            while True:
                if fIdl.tell()==end:break
                line = fIdl.readline()
                if line=="\n":continue
                now += line
                if line.endswith("};\n"):break
            result.append(now)
    else:
        while True:
            if fIdl.tell()==end:break
            now = ""
            while True:
                if fIdl.tell()==end:break
                line = fIdl.readline()
                if line=="\n":continue
                now += line
                if line.endswith("}\n"):break
            result.append(now)
    return result

def GetMethodsFromIDALegacy(binary:str, interface:str):
    interfaceName = GetInterfaceName(interface)
    interface = interface.split("\n")
    methodsFromIdl = []
    for line in interface:
        if line.find("HRESULT")!=-1: methodsFromIdl.append(line)
    print(interface)
    print(methodsFromIdl)
    methods = []
    fAsm = open("DLLs\\"+binary+".asm", "r", encoding="utf-8")
    while True:
        line = fAsm.readline()
        if line=="\n":continue
        if line == "":break
        if line.find(f"`vftable'{{for `{interfaceName}'}}")!=-1:
            line = fAsm.readline()
            if line.find("QueryInterface")!=-1:
                print("PROCESSING LINE",line)
                methods = []
                methods.append("QueryInterface")
                idlIndex = 0
                flag=True
                while True:
                    now = fAsm.tell()
                    line = fAsm.readline()
                    if line.find("vftable")!=-1:
                        fAsm.seek(now, 0)
                        if idlIndex != len(methodsFromIdl):flag=False
                        break
                    if line.find("dq offset ??")!=-1:
                        print(methods, idlIndex)
                        fAsm.seek(now, 0)
                        if idlIndex != len(methodsFromIdl):flag=False
                        break
                    if line.find("dq offset ?")==-1 or line.find("destructor")!=-1:continue
                    if len(line.split(" ; "))!=2:continue
                    if line.find("QueryInterface")!=-1:
                        methods.append("QueryInterface")
                        continue
                    if line.find("AddRef")!=-1:
                        methods.append("AddRef")
                        continue
                    if line.find("Release")!=-1:
                        methods.append("Release")
                        continue
                    if idlIndex>=len(methodsFromIdl):
                        flag=False
                        break
                    print(line)
                    pCnt1 = CountParameters(line.split(' ; ')[1])
                    pCnt2 = CountParameters(methodsFromIdl[idlIndex])
                    if pCnt1!=pCnt2:
                        print(f"Different! {pCnt1},{pCnt2}")
                        flag=False
                        break
                    print("same")
                    className = ""
                    for c in line.split(' ; ')[1].split('::')[:-1]:
                        className += c+"_"
                    methods.append(f"{className}_{line.split('dq offset ?')[1].split('@')[0]}")
                    idlIndex+=1
                    print("methods",methods)
                if flag:
                    print(methods)
                    return methods
    fAsm.close()
    print("GetMethodsFromIDA failed.")
    return []

def GetMethodsFromIDA(binary:str, interface:str):
    ret = set()
    interfaceName = GetInterfaceName(interface)
    interface = interface.split("\n")
    methodsFromIdl = []
    for line in interface:
        if line.find("HRESULT")!=-1: methodsFromIdl.append(line)
    print(interface)
    print(methodsFromIdl)
    
    fAsm = open("DLLs\\"+binary+".asm", "r", encoding="utf-8")
    while True:
        methods = []
        line = fAsm.readline()
        if line=="\n":continue
        if line == "":break
        if line.find(f"`vftable'{{for `{interfaceName}'}}")!=-1:
            while fAsm.readline().find("Release")==-1:
                continue
            methods = ["QueryInterface", "AddRef", "Release"]
            while True:
                now = fAsm.tell()
                line = fAsm.readline()
                if line.startswith("                dq offset ??"):
                    fAsm.seek(now,0)
                    break
                elif line.startswith("                dq offset ?"):
                    className = ""
                    tmp = line.split(' ; ')[1].split('::')[:-1]
                    for i in range(len(tmp)):
                        className += tmp[i]
                        if i!=len(tmp)-1:className+="::"
                    methods.append(f"/*{className}*/{line.split('dq offset ?')[1].split('@')[0]}")
                else:
                    fAsm.seek(now,0)
                    break
        if len(methods)-3==len(methodsFromIdl):ret.add(tuple(methods))
    fAsm.close()
    #print("GetMethodsFromIDA failed.")
    return ret

def GetMethodsFromCandidates(binary:str, interface:str):
    interface = interface.split("\n")
    methodsFromIdl = []
    for line in interface:
        if line.find("HRESULT")!=-1: methodsFromIdl.append(line)
    print(methodsFromIdl)
    ret = set()
    fAsm = open("DLLs\\"+binary+".asm", "r", encoding="utf-8")
    while True:
        methods = []
        line = fAsm.readline()
        if line=="\n":continue
        if line == "":break
        if line.find(f"`vftable'")!=-1:
            line = fAsm.readline()
            if line.find("QueryInterface")!=-1:
                idlIndex = 0
                candIndex = 0
                diffCnt=0
                flag=True
                while fAsm.readline().find("Release")==-1:
                    continue
                methods = ["QueryInterface", "AddRef", "Release"]
                while True:
                    now = fAsm.tell()
                    line = fAsm.readline()
                    if line.startswith("                dq offset ??"):
                        fAsm.seek(now,0)
                        break
                    elif line.startswith("                dq offset ?"):
                        if idlIndex==len(methodsFromIdl):
                            flag=False
                            break
                        pCnt1 = CountParameters(line.split(' ; ')[1])
                        pCnt2 = CountParameters(methodsFromIdl[idlIndex])
                        if pCnt1!=pCnt2:
                            print(f"different! {pCnt1} {pCnt2} {line}")
                            if len(methodsFromIdl)==1:
                                flag=False
                                break
                            diffCnt+=1
                            if len(methodsFromIdl)<10: base = 1
                            else: base = len(methodsFromIdl)//10
                            if diffCnt>base:
                                flag=False
                                break
                        print(f"same! {pCnt1} {pCnt2} {line}")
                        className = ""
                        tmp = line.split(' ; ')[1].split('::')[:-1]
                        for i in range(len(tmp)):
                            className += tmp[i]
                            if i!=len(tmp)-1:className+="::"
                        methods.append(f"/*{className}*/{line.split('dq offset ?')[1].split('@')[0]}")
                        idlIndex+=1
                    elif line.find("purecall")!=-1:
                        fAsm.seek(now,0)
                        break
                    else:
                        fAsm.seek(now,0)
                        break
                if len(methods)!=len(methodsFromIdl)+3: flag=False
                if flag: ret.add(tuple(methods))
    fAsm.close()
    return ret

def GetMethodsFromCandidatesLegacy(binary:str, interface:str):
    interface = interface.split("\n")
    methodsFromIdl = []
    for line in interface:
        if line.find("HRESULT")!=-1: methodsFromIdl.append(line)
    print(methodsFromIdl)
    ret = set()
    fAsm = open("DLLs\\"+binary+".asm", "r", encoding="utf-8")
    while True:
        methods = []
        line = fAsm.readline()
        if line=="\n":continue
        if line == "":break
        if line.find(f"`vftable'")!=-1:
            line = fAsm.readline()
            if line.find("QueryInterface")!=-1:
                methods.append("QueryInterface")
                idlIndex = 0
                candIndex = 0
                diffCnt=0
                flag=True
                while True:
                    now = fAsm.tell()
                    line = fAsm.readline()
                    if line.find("vftable")!=-1:
                        fAsm.seek(now, 0)
                        if idlIndex != len(methodsFromIdl):flag=False
                        break
                    if line.find("dq offset ??")!=-1:
                        fAsm.seek(now, 0)
                        if idlIndex != len(methodsFromIdl):flag=False
                        break
                    if line.find("dq offset ?")==-1 or line.find("destructor")!=-1:continue
                    if len(line.split(" ; "))!=2:continue
                    if line.find("QueryInterface")!=-1:
                        methods.append("QueryInterface")
                        continue
                    if line.find("AddRef")!=-1:
                        methods.append("AddRef")
                        continue
                    if line.find("Release")!=-1:
                        methods.append("Release")
                        continue
                    if idlIndex>=len(methodsFromIdl):
                        flag=False
                        break
                    print(line)
                    pCnt1 = CountParameters(line.split(' ; ')[1])
                    pCnt2 = CountParameters(methodsFromIdl[idlIndex])
                    if pCnt1!=pCnt2:
                        diffCnt+=1
                        print(f"Different! {pCnt1},{pCnt2}")
                        if len(methodsFromIdl)==1:
                            flag=False
                            break
                        base = len(methodsFromIdl)//10
                        if base==0: base=1
                        if diffCnt>base:
                            flag=False
                            break
                    print("same")
                    className = ""
                    for c in line.split(' ; ')[1].split('::')[:-1]:
                        className += c+"_"
                    methods.append(f"{className}_{line.split('dq offset ?')[1].split('@')[0]}")
                    idlIndex+=1
                if flag: ret.add(tuple(methods))
    fAsm.close()
    return ret

def CountParameters(function_declaration):
    if function_declaration.strip().endswith("(void)"):return 0
    function_definition = re.sub(r'<.*?>', '', function_declaration)
    
    # 함수 이름과 파라미터 부분 추출 (특수 소멸자 케이스 포함)
    match = re.search(r'([\w:~]+|`.*?\')\s*\((.*?)\)\s*(?:const)?(?:override)?;?$', function_definition)
    if not match:
        return 0
    
    function_name, params = match.groups()
    
    # 파라미터가 없는 경우
    if not params.strip():
        return 0
    
    # 대괄호 내부의 콤마 임시 대체
    params = re.sub(r'\[([^\]]*)\]', lambda m: m.group(0).replace(',', '<COMMA>'), params)
    
    # 템플릿 인자 내부의 콤마 임시 대체
    params = re.sub(r'<([^>]*)>', lambda m: m.group(0).replace(',', '<COMMA>'), params)
    
    # 파라미터 분리
    param_list = params.split(',')
    
    # 대체했던 콤마 복원
    param_list = [p.replace('<COMMA>', ',') for p in param_list]
    
    # 빈 파라미터 제거 및 개수 반환
    return len([p for p in param_list if p.strip()])

def ConvertMethodName(interface, methodName):
    print(methodName);#input()
    if len(methodName)==0:return interface+"\n"
    result = ""
    interface = interface.split("\n")
    index = 3
    
    if interface[0]=="[":
        for line in interface:
            
            now = line+"\n"
            if line.find("HRESULT Proc")!=-1:
                if index == len(methodName):continue
                now = line.split(" Proc")[0] + " "
                now += methodName[index]
                for tmp in line.split("(")[1:]:
                    now += "("+tmp
                now += "\n"
                index += 1
            result += now
            
    else:
        for line in interface:
            
            now = line+"\n"
            if line.find("__stdcall Proc")!=-1:
                if index == len(methodName):continue
                now = line.split(" Proc")[0] + " "
                now += methodName[index]
                for tmp in line.split("(")[1:]:
                    now += "("+tmp
                now += "\n"
                index += 1
            result += now
    print("result : ",result,methodName)
    #input()
    return result

def GetIid(content):
    content = content.split("\n")
    if content[0].startswith("["):
        for i in range(len(content)):
            line = content[i]
            if line.find("uuid(")!=-1:
                return line.split("(")[1].split(")")[0]
    else:
        return content[0].split("uuid(\"")[1].split("\"))")[0]

def GetAppId(clsid):
    try:
        path = f"CLSID\\{clsid}"
        key = winreg.OpenKey(winreg.HKEY_CLASSES_ROOT, path, 0, winreg.KEY_READ)
        appid, regtype = winreg.QueryValueEx(key, "AppID")
        return appid
    except Exception as e:
        return None

def GetInprocServer32(clsid):
    try:
        path = f"CLSID\\{clsid}\\InprocServer32"
        key = winreg.OpenKey(winreg.HKEY_CLASSES_ROOT, path, 0, winreg.KEY_READ)
        appid, regtype = winreg.QueryValueEx(key, None)
        return appid
    except Exception as e:
        return None

def GetLocalServer32(clsid):
    try:
        path = f"CLSID\\{clsid}\\LocalServer32"
        key = winreg.OpenKey(winreg.HKEY_CLASSES_ROOT, path, 0, winreg.KEY_READ)
        appid, regtype = winreg.QueryValueEx(key, None)
        return appid
    except Exception as e:
        return None

def GetServiceName(appId):
    try:
        path = f"AppID\\{appId}"
        key = winreg.OpenKey(winreg.HKEY_CLASSES_ROOT, path, 0, winreg.KEY_READ)
        name, regtype = winreg.QueryValueEx(key, "LocalService")
        return name
    except Exception as e:
        return None

def GetBinaryPath(name):
    try:
        path = f"SYSTEM\\ControlSet001\\Services\\{name}\\Parameters"
        key = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, path, 0, winreg.KEY_READ)
        name, regtype = winreg.QueryValueEx(key, "ServiceDLL")
        return name.lower().replace("%systemroot%", "C:\\Windows").replace('"', '').replace("%programfiles%", "C:\\Program Files").replace("%windir%", "C:\\Windows").split(" ")[0]
    except Exception as e:
        try:
            path = f"SYSTEM\\ControlSet001\\Services\\{name}"
            key = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, path, 0, winreg.KEY_READ)
            name, regtype = winreg.QueryValueEx(key, "ImagePath")
            return name.lower().replace("%systemroot%", "C:\\Windows").replace('"', '').replace("%programfiles%", "C:\\Program Files").replace("%windir%", "C:\\Windows").split(" ")[0]
        except Exception as e:

            fResult = open(RESULT_PATH, "w")
            ErrorExit(fResult, e)

IDAT_PATH = GetIDATPath(r"Local Settings\Software\Microsoft\Windows\Shell\MuiCache")
IDL_PATH = "interfaces\\idls\\before.interface"
RESULT_PATH = "interfaces\\idls\\after.interface"


def main():
    fResult = open(RESULT_PATH, "w")
    # sys.argv[1] : binary path
    # sys.argv[2] : IDL Path
    clsid = None
    interfaces = GetInterfacesFromIDL(IDL_PATH)
    SERVICE_NAME = None
    for interface in interfaces:
        if interface=="":continue
        if interface.find("[id")!=-1:
            fResult.write(interface)
            continue
        path = f"interfaces\\iids\\{GetIid(interface)}.txt"
        print(path)
        #input()
        if os.path.exists(path):
            fIid = open(path, "r")
            clsid = "{"+fIid.read()+"}"
            appId = GetAppId(clsid)
            if appId==None:continue
            SERVICE_NAME = GetServiceName(appId)
            break
    print(SERVICE_NAME)
    
    #input()
    if SERVICE_NAME!=None:
        BINARY_PATH = GetBinaryPath(SERVICE_NAME)
    else:
        BINARY_PATH = GetInprocServer32(clsid)
        if BINARY_PATH==None:
            BINARY_PATH = GetLocalServer32(clsid)
        if BINARY_PATH==None:
            ErrorExit(fResult, "CAN'T FIND DLL")
    print("Hello?")
    #input()
    BINARY_NAME = GetBinaryName(BINARY_PATH)
    print("here", SERVICE_NAME, IDL_PATH, IDAT_PATH, RESULT_PATH, BINARY_PATH, BINARY_NAME)


    if not os.path.exists("DLLs"):
        os.makedirs("DLLs")
    try:
        shutil.copy(BINARY_PATH,"DLLs\\"+BINARY_NAME)
    except Exception as e:
        ErrorExit(fResult, e)

    if not os.path.exists("DLLs\\"+BINARY_NAME+".asm"):
        if not get_asembly(IDAT_PATH, "DLLs\\"+BINARY_NAME):
            ErrorExit(fResult, "IDAT ERROR")
    fResult = open(RESULT_PATH, "w")
    for interface in interfaces[:-1]:
        methods = list(GetMethodsFromIDA(BINARY_NAME, interface))
        if len(methods)==0:
            candidates = list(GetMethodsFromCandidates(BINARY_NAME, interface))
            if len(candidates)==0:
                fResult.writelines([f"// RESOLVE FAILED : {BINARY_PATH}\n"])
                fResult.write(interface)
            for i in range(len(candidates)):
                fResult.writelines([f"// Candidate {i+1}\n"])
                fResult.write(ConvertMethodName(interface, candidates[i]))
            continue
        for i in range(len(methods)):
            if len(methods)!=1: fResult.writelines([f"// Candidate {i+1}\n"])
            fResult.write(ConvertMethodName(interface, methods[i]))
    fResult.close()
    fResult = open(RESULT_PATH, "r")
    fResult.seek(0, 2)
    size = fResult.tell()
    fResult.seek(0,0)
    content = fResult.read(size)
    fResult.close()
    fResult = open(RESULT_PATH, "w")
    fResult.writelines([f"// {BINARY_PATH}\n",content])
    fResult.close()
if __name__ == "__main__":
    main()
    input()
    sys.exit(0)