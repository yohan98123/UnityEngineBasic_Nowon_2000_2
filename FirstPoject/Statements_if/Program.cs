using System;

namespace Statements_if
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition1 = false;
            bool condition2 = false;
            bool condition3 = true;

            if (condition1)
            {
                // 조건1이 참일때 실행할 내용
                Console.WriteLine("조건1은 참");
            }
            else if (condition2)
            {
                // 조건2가 참일때 실행할 내용
                Console.WriteLine("조건 1은 거짓이고, 조건 2는 참");
            }
            else if (condition3)
            {
                // 조건3이 참일 때 실행할 내용
                Console.WriteLine("조건 1,2가 거짓이고, 조건 3은 참");
            }    
        }
    }
}
