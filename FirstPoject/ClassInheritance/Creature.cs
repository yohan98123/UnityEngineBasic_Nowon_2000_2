using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    internal class Creature
    {
        public string DNA;
        public int age;
        public float mass;

        public void Breath()
        {
            Console.WriteLine("나는 숨을 쉰다");
        }
    }
}
