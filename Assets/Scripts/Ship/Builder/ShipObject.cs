using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipObject
{
    public ShipComponent_Room[,] rooms;
    public ShipComponent_Mechanism[,] mechanisms;
    public ShipComponent_Engine[,] engines;


    public ShipObject (int width, int height)
    {
        rooms = new ShipComponent_Room[width, height];
        mechanisms = new ShipComponent_Mechanism[width, height];
        engines = new ShipComponent_Engine[width, height];
    }

    public void SetRoom(Vector2 pos, ShipComponent_Room room)
    {
        rooms[(int)pos.x, (int)pos.y] = room;
    }

    public void SetMechanism(Vector2 pos, ShipComponent_Mechanism mech)
    {
        mechanisms[(int)pos.x, (int)pos.y] = mech;
    }

    public void SetEngine(Vector2 pos, ShipComponent_Engine engine)
    {
        engines[(int)pos.x, (int)pos.y] = engine;
    }
}
