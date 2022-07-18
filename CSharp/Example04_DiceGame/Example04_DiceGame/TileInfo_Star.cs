using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example05_DiceGame
{
    internal class TileInfo_Star : TileInfo
    {
        public int starValue = 3; //플레이어가 획득 할 수있는 샛별 갯수

        public override void OnTile()
        {
            base.OnTile();
            starValue++; //플레이어가 휙득할 수 있는 샛별 수 증가
        }
    }

    
}
