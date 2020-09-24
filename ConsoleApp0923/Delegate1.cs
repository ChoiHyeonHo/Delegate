using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    class MyClass
    {
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public void Plus(int val) //int val = 0; => 선택적 파라미터
        {
            number += val;
        }
        public void Minus(int val)
        {
            number -= val;
        }
        public void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }
        public static void PrintHello(int val)
        {
            for (int i = 0; i < val; i++)
            {
                Console.WriteLine("Hello");
            }
        }
    }

    delegate void Sample(int value);
    class Delegate1
    {
        static void Main()
        {
            MyClass c1 = new MyClass(); //number = 0

            //직접 인스턴스 메서드를 호출
            //c1.Plus(100); //number = 100
            //c1.Minus(10); //number = 90
            //c1.Add(10, 20); //30출력
            //Console.WriteLine(c1.Number); //90출력

            Sample s1 = new Sample(c1.Plus); //c1.Add는 파라미터가 2개라서 서로 다르기때문에 안됨
            s1 += new Sample(c1.Minus); // C# 1.0문법
            s1(100); //Plus(100), Minus(100)
            s1 -= new Sample(c1.Minus);
            s1(100); //Plus(100)
            Console.WriteLine(c1.Number);

            s1 = c1.Minus; // C# 2.0문법
            s1 += c1.Plus;
            s1 += c1.Plus;
            s1(200); //Minus(200), Plus(200), Plus(200)
            Console.WriteLine(c1.Number); //300

            s1 += MyClass.PrintHello; //static 메서드도 가능하다.
            s1(5); //Minus(5), Plus(5), Plus(5), PrintHello(5)
            Console.WriteLine(c1.Number); 
        }
    }
}
