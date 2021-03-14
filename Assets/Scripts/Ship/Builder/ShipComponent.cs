using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ShipComponent : ScriptableObject
{
    public string displayname;
    public string description;
    public GameObject inner;
    public GameObject outer;
    public Vector2 position;
    public Vector2 size = new Vector2(1, 1);
    public bool[] requiredConnections = new bool[4];
}
