using System;

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

            Human human1 = new Human(100f,'남');
            Human human2 = new Human(200f,'여');


            human1.age = 100;
            human1.height = 200f;
            human1.genderChar = '남';
            human2.age = 50;
            human2.height = 150f;
            human2.genderChar = '여';


            Console.WriteLine("human1의 나이, 키, 성별은?");
            Console.WriteLine(human1.age);
            Console.WriteLine(human1.height);
            Console.WriteLine(human1.genderChar);
            Console.WriteLine("human2의 나이, 키, 성별은?");
            Console.WriteLine(human2.age);
            Console.WriteLine(human2.height);
            Console.WriteLine(human1.genderChar);


            human1.SayMyAge();
            human2.SayMyAge();           
        }
    }

    class Human 
    {
        // 접근 제한자
        // private : 외부 클래스 / 객체에서 접근할 수 없도록 제한
        // public : 외부 클래스 / 객체에서 접근할 수 있도록 제한해제
        // internal : 동일 프로젝트에서 접근 가능 public 처럼 동작함
        // protected : 자식만 접근 가능하도록 제한
        //
        // class 의 멤버들은 접근제한자를 명시하지 않으면 기본적으로 private를 
        // 접근 제한자를 정확하게 명시해야하는 이유는
        // 제3자가 봤을때 접근하면 안되는 멤버에 접근하는 등의 사고로 인해
        // 코드를 잘못 작성할 가능성을 없애기 위함
        public int age;
        public float height;
        public char genderChar;        
       
        public void SayMyAge() 
        {
            Console.WriteLine(age);
            Console.WriteLine(height);
        }

        public Human(float height, char genderChar)
        {
            this.height = height;
            this.genderChar = genderChar;  
        }
    }
  
   

}
