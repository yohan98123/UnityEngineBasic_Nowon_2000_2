﻿using System;

// Hunan 클래스를 만들고
// ( 정수형 나이, 실수형 키, 문자형 성별 문자 를 멤버 변수로 가지고
//   나이를 Console 창에 출력하는 함수를 멤버 함수로 가진다
// Human 객체 2개 생성
// human1 의 나이 100, 키 200, 성별 남
// Human2 의 나이 50, 키 150, 성별 여
//프로그램을 실행하면 각 사람이 본인의 나이를 콘솔창에 출력하도록 함.

namespace InstantiationExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            Human human1 = new Human();
            Human human2 = new Human();            
            human1.age = 100;
            human1.height = 200f;
            human1.gender = '남';           
            human2.age = 50;
            human2.height = 150f;
            human2.gender = '여';
            Console.WriteLine("human1의 나이, 키, 성별은?");
            Console.WriteLine(human1.age);
            Console.WriteLine(human1.height);
            Console.WriteLine(human1.gender);
            Console.WriteLine("human2의 나이, 키, 성별은?");
            Console.WriteLine(human2.age);
            Console.WriteLine(human2.height);
            Console.WriteLine(human1.gender);
            
        }
    }
    
    class Human 
    {
        public int age;
        public float height;
        public char gender;    
    }
  
   

}
