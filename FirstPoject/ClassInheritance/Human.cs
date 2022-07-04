using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    internal class Human : Creature
    {
        public string name;
        public float height;

        // virtual : 자식클래스가 재정의 할 수 있도록 하는 키워드
        public virtual void Grow()
        {
            mass += 10.0f;
            height += 5.0f;
            Console.WriteLine($"{name}이 자랐다 ! {mass}, {height}");
                
        }
    }
}
