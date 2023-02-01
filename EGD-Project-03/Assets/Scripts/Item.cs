using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        SheepScoop,
        SpawnSpeed,
        MPS,
        GrinderSize,
        Favor,
        FunnelSize
    }

    public static int GetCost(ItemType item)
    {
        switch (item)
        {
            default:
            // case ItemType.SheepScoop:       return 300;
            case ItemType.SpawnSpeed:       return 600;
            case ItemType.MPS:              return 150;
            case ItemType.GrinderSize:      return 800;
            case ItemType.Favor:            return 200;
            case ItemType.FunnelSize:       return 500;
        }
    }
}
