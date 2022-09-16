using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelInfo", menuName = "TowerDefence/LevelInfo")]

public class LevelInfo : ScriptableObject
{
    public int lifeInit;
    public int moneyInit;
}
