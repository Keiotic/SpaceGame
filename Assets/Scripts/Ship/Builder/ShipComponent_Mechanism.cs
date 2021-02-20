using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponent_Gun", menuName = "data/shipdata/components/gun")]
[System.Serializable]
public abstract class ShipComponent_Mechanism : ShipComponent 
{
    public GameObject auxObject;
    public Vector2 auxPosition;
    public Vector2 auxSize = new Vector2(1, 1);
    public Vector2 auxConnection;
}
