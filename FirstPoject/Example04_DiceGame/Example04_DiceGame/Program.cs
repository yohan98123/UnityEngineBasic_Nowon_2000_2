using System;

namespace Example04_DiceGame
{
    internal class Program
    {
        static private int totalTile = 20; //맵타일수
        static private int currntStarPoint; // 현재 샛별수
        static private int totalDiceNumber = 20; // 총 주사위 수
        static private int currentTileIndex = 0; // 현재 플레이어 위치
        static private int previousTileIndex = 0; // 이전 플레이어 우치
        static private Random random;
        static void Main(string[] args)
        {
            //맵 생성
            TileMap map = new TileMap();
            map.MapSetUp(totalTile);

            int currentDiceNumber = totalDiceNumber; // 현재 주사위 갯수

            while (currentDiceNumber > 0)
            {
                int diceValue = RollADice();
                currentDiceNumber--; // 주사위갯수 차감
                currentTileIndex += diceValue; //주사위 눈금만큼 플레이어 전진

               

                // 플레이어가 샛별칸을 몇개 지났는지 체크
                int passedStarTileNum = currentTileIndex / 5 - previousTileIndex / 5;
                for (int i = 0; i < passedStarTileNum; i++)
                {
                    int starTileIndex = (currentTileIndex / 5 - i) * 5;

                    if (starTileIndex > totalTile)
                        starTileIndex -= totalTile;

                    if (map.tiles.TryGetValue(starTileIndex, out TileInfo tileInfo_star))
                    {
                        currntStarPoint += (tileInfo_star as TileInfo_Star).starValue;
                    }
                    else
                    {
                        throw new Exception("샛별 칸 정보를 가져오는데 실패 했습니다");
                    }
                }

                if (currentTileIndex >= totalTile - 1)
                    currentTileIndex -= totalTile;

                if (map.tiles.TryGetValue(currentTileIndex, out TileInfo tileInfo))
                {
                    tileInfo.OnTile();
                }
                else
                {
                    throw new Exception("플레이어가 맵을 이탈했습니다.");
                }

                
                previousTileIndex = currentTileIndex;
                Console.WriteLine($"현재 샛별점수 : {currntStarPoint}");
                Console.WriteLine($"현재 남은 주사위 갯수{currentDiceNumber}");
            }

            Console.WriteLine($"게임 끝! 점수 : {currntStarPoint}");
        }

        static private int RollADice()
        {
            string userInput = "Default";
            while (userInput != "")
            {
                Console.WriteLine("엔터키로 주사위를 굴리세요..!");
                userInput = Console.ReadLine();

            }
            random = new Random();
            int diceValue = random.Next(1, 7);
            Console.WriteLine($"주사위를 굴렸다..! 눈금은 {diceValue} 다!");
            DisplayDice(diceValue);
            return diceValue;
        }

        static void DisplayDice(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("└───────────┘");
                    break;
                case 2:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 3:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 4:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 5:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 6:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                default:
                    break;
            }
        }
        // 현재 칸의 번호를 넣어주면 지나온 샛별칸의 번호를 반환해주는 함수
        static public int CalcPassedStarTileIndex(int currentTileIndex)
        {
            int index = currentTileIndex / 5 * 5;
            return index;
        }
    
    }
}
