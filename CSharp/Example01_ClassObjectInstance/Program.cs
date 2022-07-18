using System;
//**객체선정 :** 

//오크(orc)

//추상화
//오크는
//[이름, 키, 몸무게, 나이, 성별문자, 쉬고있는지 ? ]에 대한 특징과
//[휘두르기, 점프하기] 의 기능을 가지고 있다.

//객체화, 인스턴스화
//오크 객체 2 마리를 만들고
//첫번째 오크에게는
//이름 : 상급오크
//키: 240.2
//무게: 200
//나이: 140
//성별문자: 남
//쉬고있는지? : 거짓
//두번째 오크에게는
//키: 140.4
//무게: 120
//나이: 60
//성별문자: 여
//쉬고있는지? : 참의 값을 초기화해준다.

//동작수행

//만약에 첫번째 오크가 쉬고있으면
//점프와 휘두르기 를 시전하고
//쉬고있지 않으면 "{오크이름} (이)가 바쁘다" 라는 문장을 콘솔창에 출력
//만약에 두번째 오크가 쉬고있으면
//점프와 휘두르기 를 시전하고
//쉬고있지 않으면 "{오크이름} (이)가 바쁘다" 라는 문장을 콘솔창에 출력

namespace Example01_ClassObjectInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            // this 키워드
            // 객체 자기자신을 참조하는 키워드
            Orc orc1 = new Orc();
            orc1.name = "상급오크";
            orc1.height = 240.2f;
            orc1.weight = 200f;
            orc1.age = 140;
            orc1.genderChar = '남';
            orc1.IsResting = false;

            Orc orc2 = new Orc();
            orc2.name = "하급오크";
            orc2.height = 140.4f;
            orc2.weight = 120f;
            orc2.age = 60;
            orc2.genderChar = '여';
            orc2.IsResting = true;

            if (orc1.IsResting)
            {
                orc1.Jump();
                orc1.Smash();
            }  
            else
            {
                Console.WriteLine($"{orc1} (이)가 바쁘다"); 
            }
            if (orc2.IsResting)
            {
                orc2.Jump();
                orc2.Smash();
            }
            else 
            {
                Console.WriteLine($"{orc2} (이)가 바쁘다");
            }

        }
        class Orc
        {
            public string name;
            public float height;
            public float weight;
            public int age;
            public char genderChar;
            public bool IsResting;
            public void Smash()
            {
                Console.WriteLine($"{name}(이)가 휘둘렀다!");
            }
            public void Jump()
            {
                Console.WriteLine($"{name}(이)가 점프했다!");
            }

         }
        

        
    }
}
