using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    class CPoint3D //시스템.오브젝트 - 시스템.밸류 - 구조체 상속이기 때문에 ToString 가능
    {
        public int x;
        public int y;
        public int z;

        public CPoint3D()
        {

        }
        public CPoint3D(int x, int y, int z) //구조체에서는 기본 생성자를 정의 불가. 파라미터를 모두 정의해야함.
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"(x, y, z) = ({x}, {y}, {z})";
        }

    }
    class MyClass1
    {
        static void Main()
        {
            //CPoint3D point;
            //point.x = 20; //클래스는 반드시 new 해야함
            //point.y = 10;
            //point.z = 5;

            //Console.WriteLine(point.ToString());

            CPoint3D point1 = new CPoint3D();
            point1.x = 70;
            point1.y = 50;
            point1.z = 40;

            Console.WriteLine(point1.ToString());

            CPoint3D point2 = new CPoint3D(90, 30, 10); //구조체에서 생성자를 쓰는 이유는 34~37줄까지의 4줄을 쓰기 귀찮아서.
            Console.WriteLine(point2.ToString());

            CPoint3D point3 = point2;
            point3.z = 900;
            Console.WriteLine(point2.ToString());
            Console.WriteLine(point3.ToString());  //ref타입은 밸류로 하더라도 같이 영향을 받는다. 클래스와 구조체를 선택하는 기준.
        }
    }
}
