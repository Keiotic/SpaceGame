using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ShipObject : ScriptableObject
{
    public List<List<ShipComponent_Room>> rooms;
    public List<List<ShipComponent_Gun>> guns;
}
