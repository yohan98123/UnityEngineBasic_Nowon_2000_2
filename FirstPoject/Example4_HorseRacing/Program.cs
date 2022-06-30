using System;
using System.Threading;
//- 진행방식 -
//
//프로그램 시작시
//말 다섯마리를 만들고 (말 클래스 구현해야함 ) o
//각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
//각각의 말이 거리 200 에 도달하면 말의 이름과 등수를 출력해줌
//
//말은
//이름, 달린거리 를 멤버변수로 o
//달리기 를 멤버 함수로 가짐. o 
//달리기 멤버함수는 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할을 함.
//
//매초 달릴 때 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
//경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.
//
//### - Hint -
//
//System.Threading namespace 에 있는 Thread.Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬수 있음
//While 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
namespace Example4_HorseRacing
{
    internal class Program
    {
        static Random random;
        static bool isGameFinished = false;
        static int minspeed = 10;
        static int maxspeed = 20;
        static int finishDistance = 200;

        static void Main(string[] args)
        {        
            Horse[] arr_horse = new Horse[5];
            string[] arr_FinishedHorseName = new string[5]; // 결승점을 통과할 말의 이름을 저장한 배열
            int currentGrade = 1; //현재 등수
            int lenth = arr_horse.Length;
            for (int i = 0; i < lenth; i++)
            {
                arr_horse[i] = new Horse();
                arr_horse[i].name = $"경주마{i+1}";
            }
            Console.WriteLine("경주시작!");
            int count = 0;
            
            //경주중
            while (isGameFinished == false)
            {
                Console.WriteLine($"======================={count}초=======================");
                for (int i = 0; i < length; i++)
                {
                    if (arr_horse[i].dontMove == false)
                    {
                        random = new Random();
                        int tmpMoveDistance = random.Next(minspeed, maxspeed + 1);
                        arr_horse[i].Run(tmpMoveDistance);

                    }
                }
                Thread.Sleep(1000);

            }
        }
    }

    class Horse

    {
        public string name;
        public int distance;
        public bool dontMove;
        public void Run(int movedistance)
        {
            distance += movedistance;
        }
            

    }
}
