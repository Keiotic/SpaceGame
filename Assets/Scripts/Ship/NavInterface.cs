using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavInterface : ShipInterface
{
    public void Awake()
    {
        Setup();
    }
    public void Update()
    {
        if(IsInteractable(playerInterface)&&!inRange)
        {

        }
        else if(!IsInteractable(playerInterface)&&inRange)
        {

        }
    }
    public override void PlayerDeath(PlayerInterface playerInterface)
    {
        Deactivate(playerInterface);
    }
    public void Setup()
    {
        if (FindObjectOfType<PlayerInterface>())
        {
            playerInterface = FindObjectOfType<PlayerInterface>();
        }
    }

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

    public override void Interact(PlayerInterface playerInterface)
    {
        if (!busy)
        {
            Activate(playerInterface);
        }
        else
        {
            Deactivate(playerInterface);
        }
    }

}
