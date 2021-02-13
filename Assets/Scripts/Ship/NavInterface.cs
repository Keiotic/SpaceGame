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
            playerInterface.AddToInteractableQueue(this);
            inRange = true;
        }
        else if(!IsInteractable(playerInterface)&&inRange)
        {
            playerInterface.RemoveFromInteractableQueue(this);
            inRange = false;
        }

        if(!playerInterface && FindObjectOfType<PlayerInterface>())
        {
            playerInterface = FindObjectOfType<PlayerInterface>();
        }
    }
    public override void PlayerDeath(PlayerInterface playerInterface)
    {
        Deactivate(playerInterface);
    }
    public void ComponentDeath()
    {
        if (connectedPlayer)
        {
            Deactivate(connectedPlayer);
        }
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
        busy = false;
    }

    public override void Deactivate(PlayerInterface player)
    {
        connectedPlayer = null;
        player.SetShipInterface(null);
        busy = false;
    }

    public override void Input(PlayerInterface player)
    {

    }

    public override void Interact(PlayerInterface playerInterface)
    {
        if (!busy)
        {
            if(connectedPlayer != playerInterface)
            Activate(playerInterface);
            else
            Deactivate(playerInterface);
        }
    }

}
