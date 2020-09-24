using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0923
{
    class SingerNameComparer : IComparer//비교 전용 인터페이스
    {
        public int Compare(object x, object y) //문자열은 크다작다가 없기 때문에.
        {
            //이름이 크면 1, 작으면 -1, 같으면 0
            Singer first = x as Singer;
            Singer second = y as Singer;

            if (first.Name.CompareTo(second.Name) == 1)
                return 1;
            else if (first.Name.CompareTo(second.Name) == -1)
                return -1;
            else
                return 0;
        }
    }
    class Singer : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AlbumCnt { get; set; }

        public Singer(string name, int age, int albumCnt)
        {
            Name = name;
            Age = age;
            AlbumCnt = albumCnt;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}세 - {AlbumCnt}집 앨범";
        }

        public int CompareTo(object obj)
        {
            //나이가 크면 1, 작으면 -1, 같으면 0
            Singer sing = obj as Singer;

            if (this.Age > sing.Age)
                return -1;
            else if (this.Age < sing.Age)
                return 1;
            else
                return 0;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singer[] singers = new Singer[5] {
                    new Singer("아이유", 28, 8),
                    new Singer("자우림", 40, 5),
                    new Singer("거미", 35, 5),
                    new Singer("이승철", 50, 15),
                    new Singer("태진아", 65, 5)
            };

            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

            Console.WriteLine("======================================");
            Console.WriteLine();

            Array.Sort(singers); //int는 값의 크기에 따라 정렬, string은 CompareTo //나이로 정렬


            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

            Console.WriteLine("======================================");
            Console.WriteLine();

            SingerNameComparer nameComparer = new SingerNameComparer();
            Array.Sort(singers, nameComparer); //이름으로 정렬


            foreach (Singer sing in singers)
            {
                Console.WriteLine(sing.ToString());
            }

        }
    }
}
