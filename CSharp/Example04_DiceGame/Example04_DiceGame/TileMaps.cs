﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example05_DiceGame
{
    internal class TileMap
    {
        public Dictionary<int, TileInfo> tiles = new Dictionary<int, TileInfo>();
        
        public void MapSetUp(int maxTileNum)
        {
            for (int i = 1; i <= maxTileNum; i++)
            {
                if (i % 5 == 0) 
                {
                    TileInfo_Star tileInfo_Star = new TileInfo_Star();
                    tileInfo_Star.index = i;
                    tileInfo_Star.name = "샛별";
                    tileInfo_Star.discription = "샛별을 샛별을 획들할 수있는 칸입니다.";
                    tiles.Add(i, tileInfo_Star);
                }
                else
                {
                    TileInfo tileInfo = new TileInfo();
                    tileInfo.index = i;
                    tileInfo.name = "일반";
                    tileInfo.discription = "이칸은 아무 이벤트가 없습니다.";
                    tiles.Add(i, tileInfo);

                }
            }
        }


       
    }
}
