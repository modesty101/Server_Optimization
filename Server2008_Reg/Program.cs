using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Server2008_Reg
{
    class Program
    {
        // 윈도우 서버 2008 설정
        static void Main(string[] args)
        {
            // 하위 키를 열고, 두번째 인자로 true를 설정하면 쓰기 권한이 부여됨
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\", true);

            if (reg == null)
            {
                Console.WriteLine("레지스트리 오픈 실패!");
                return;
            }
            else
            {
                // 이용 가능 포트 수를 최대로 지정
                reg.SetValue("MaxUserPort", 0x0000FFFF, RegistryValueKind.DWord);

                // 연결 지연시 유지 시간을 30초로 지정
                reg.SetValue("TcpTimedWaitDelay", 0x0000001e, RegistryValueKind.DWord);

                // 네트워크에서 직접 메모리에 접근하는 기술, 비활성화
                reg.SetValue("EnableTCPA", 0x00000000, RegistryValueKind.DWord);

                Console.WriteLine("레지스트리 설정 성공!");
            }

            Console.ReadKey();
        }
    }
}
