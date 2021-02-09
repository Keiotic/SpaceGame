using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavInterface : ShipInterface
{
    public override void Activate(PlayerInterface player)
    {
        connectedPlayer = player;
        player.SetShipInterface(this);
    }
    public override void Deactivate(PlayerInterface player)
    {
        connectedPlayer = null;
        player.SetShipInterface(null);      
    }
    public override void Input(PlayerInterface player)
    {

    }

}
