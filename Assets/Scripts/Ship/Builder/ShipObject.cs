using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipObject
{
    public List<List<ShipComponent_Room>> rooms;
    public List<List<ShipComponent_Mechanism>> mechanisms;
    

    public ShipObject (int width, int height)
    {
        List<ShipComponent> innerlist = new List<ShipComponent>(height);
        for (int i = 0; i < height; i++)
        {
            innerlist.Add(null);
        }
        List<List<ShipComponent>> outerlist = new List<List<ShipComponent>>();
        for(int i = 0; i < width; i++)
        {
            outerlist.Add(innerlist);
        }
    }
}
