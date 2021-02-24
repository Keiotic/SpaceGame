using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponents", menuName = "data/shipdata/shipcomponents")]
[System.Serializable]
public class ShipComponents : ScriptableObject
{
    public List<ShipComponent_Engine> engines;
    public List<ShipComponent_Room> exteriors;
    public List<ShipComponent_Room> rooms;
    public List<ShipComponent_Gun> weapons;
    public List<ShipComponent_Shield> shields;
    public List<GameObject> misc;
    public bool[] requiredConnections = new bool[4];
}

