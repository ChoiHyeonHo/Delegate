using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    struct Point3D //시스템.오브젝트 - 시스템.밸류 - 구조체 상속이기 때문에 ToString 가능
    {
        public int x;
        public int y;
        public int z;

        public Point3D(int x, int y, int z) //구조체에서는 기본 생성자를 정의 불가. 파라미터를 모두 정의해야함.
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


    class MyStruct1 //new 해도되고 안해도 됨(구조체와 클래스의 차이점.)
    {
        static void Main()
        {
            Point3D point;
            point.x = 20;
            point.y = 10;
            point.z = 5;

            Console.WriteLine(point.ToString());

            Point3D point1 = new Point3D();
            point1.x = 70;
            point1.y = 50;
            point1.z = 40;

            Console.WriteLine(point1.ToString());

            Point3D point2 = new Point3D(90, 30, 10); //구조체에서 생성자를 쓰는 이유는 34~37줄까지의 4줄을 쓰기 귀찮아서.
            Console.WriteLine(point2.ToString());

            Point3D point3 = point2;
            point3.z = 900;
            Console.WriteLine(point2.ToString());
            Console.WriteLine(point3.ToString()); //Value 타입이라는 증거.
        }
    }
}
