using System;

namespace OperatorMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            Console.WriteLine(OperatorMethods.Sum(1, 2));
            Console.WriteLine(OperatorMethods.Sub(1, 2));
            Console.WriteLine(OperatorMethods.Div(1, 2));
            Console.WriteLine(OperatorMethods.Mul(1, 2));
            Console.WriteLine(OperatorMethods.Mod(1.0f, 2.0f));
            Console.WriteLine(OperatorMethods.Decrease(a));
            Console.WriteLine(OperatorMethods.Increase(a));
            Console.WriteLine(OperatorMethods.IsSame(1, 2));


        }
    }
}
