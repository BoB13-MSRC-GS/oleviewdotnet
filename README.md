# oleviewdotnet

OleView .NET은 RpcView와 다르게 심볼을 로드하는 기능이 없어 IDL에 메소드명이 `Proc{n}`으로 뜨는 문제점이 있습니다. 이 레포지토리는 해당 부분을 최대한 개선한 버전입니다.

### IDL Method Name Resolve
- **해당 기능을 사용하려면 Processes 탭의 "Resolve Method Name by IDA"를 활성화해야 합니다.**

- IDL 최상단에 해당 바이너리의 경로가 표시됩니다.
- IDL에 `// Candidate {n}`이 표시되는 경우에는 메소드 개수와 인자 개수를 비교하여 추측된 것이므로 정확하지 않을 수 있습니다.
- View Proxy Library 기능을 사용하는 경우에도 어느정도 메소드명을 추출해주지만, 여러 서비스가 공유하는 Proxy DLL의 경우에는 제대로 추출되지 않을 수 있습니다.
- 메소드명을 추출하기 위해 IDA를 사용하므로, 레지스트리에 IDA 경로 등록을 위해 한 번이라도 ida64.exe를 실행한 적이 있어야 합니다.
- **최초 1회 DLL 복사 및 idat64.exe를 이용한 분석 과정에서 약간의 시간이 소요될 수 있습니다.**

### 클래스 클릭 시 인터페이스 미추출 문제 해결
- 클래스를 클릭하였을 때 인터페이스가 추출되지 않는 경우가 있어, 이를 CoCreateInstance 함수를 이용해 추출해줍니다.
