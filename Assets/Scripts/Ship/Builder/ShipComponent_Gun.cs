using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponent_Gun", menuName = "data/shipdata/components/gun")]
[System.Serializable]
public class ShipComponent_Gun : ShipComponent 
{
    public GameObject gun;
    public Vector2 gunPosition;
    public Vector2 gunSize = new Vector2(1, 1);
}
