using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponent_Room", menuName = "data/shipdata/components/room")]
[System.Serializable]
public class ShipComponent_Room : ShipComponent 
{
    public enum WallType
    {
        open_wall,
        wall,
        none
    }
    public WallType[] walls = new WallType[4] {WallType.open_wall, WallType.open_wall, WallType.open_wall, WallType.open_wall};
}
