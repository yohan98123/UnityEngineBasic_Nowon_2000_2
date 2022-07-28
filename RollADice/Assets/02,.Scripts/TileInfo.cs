using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour, IComparable<TileInfo>
{
    public int index;
    new public string name;
    public string discription;

    public virtual void OnTile()
    {
        Debug.Log($"����� {index} ��° ĭ�� {name}, {discription}");
    }

    public int CompareTo(TileInfo other)
    {
        return index - other.index;
    }
    // ������ �����ε�
    public static bool operator > (TileInfo op1, TileInfo op2)
    {
        return op1.index > op2.index;
    }

    public static bool operator < (TileInfo op1, TileInfo op2)
    {
        return op1.index < op2.index;
    }
}
