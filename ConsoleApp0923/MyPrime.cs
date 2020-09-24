using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    delegate void FindDelegate(int prime); // delegate void 델리게이트명(파라미터); => 델리게이트 정의 
    class MyPrime
    {
        //클래스 안쪽으로 이벤트 정의
        public event FindDelegate FindPrime; //public event 델리게이트명 이벤트명; => 이벤트 정의

        public void CheckPrime(int maxNum)
        {
            int cnt = 0;
            bool bPrime;
            for (int i = 2; i <= maxNum; i++) // 1번 for문
            {
                bPrime = true;
                for (int p = 2; p <i; p++) // 2번 for문
                {
                    if (i % p == 0)
                    {
                        bPrime = false;
                        break;
                    }
                }
                if (bPrime)
                {
                    //Console.Write($"{i}, ");
                    FindPrime(i); //이벤트명(전달할 값); => 이벤트 발생
                }
            }
        }
    }

    class MyPrimeTest
    {
        static void Main()
        {
            Console.Write("솟수를 구하고 싶은 범위의 최대값을 입력");
            int maxNum = int.Parse(Console.ReadLine());

            MyPrime pi = new MyPrime(); 
            pi.FindPrime += PrintPrime; //이 이벤트가 일어나면 += 이 함수 호출 => 이벤트 핸들러 등록 이벤트명 += 메서드명; C# 2.0문법

            //pi.FindPrime += new FindDelegate(PrintPrime); //C# 1.0문법
            pi.CheckPrime(maxNum);
        }

        private static void PrintPrime(int prime) //이벤트 발생시 호출
        {
            Console.WriteLine("이벤트 발생: " + prime);
        }
    }
}
