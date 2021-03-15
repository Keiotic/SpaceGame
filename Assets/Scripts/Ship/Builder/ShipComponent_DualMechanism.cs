using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponent_Mechanism", menuName = "data/shipdata/components/Mechanism")]
[System.Serializable]
public abstract class ShipComponent_DualMechanism : ShipComponent 
{
    public GameObject auxObject;
    public Vector2 auxPosition;
    public Vector2 auxSize = new Vector2(1, 1);
    public Vector2 auxConnection;
}
