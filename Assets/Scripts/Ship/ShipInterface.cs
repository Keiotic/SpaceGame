using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipInterface : Interactable
{
    public PlayerInterface connectedPlayer;
    public List<GameObject> engines;
    GameObject player;
    public float activationDistance = 4;
    public bool busy = false;

    public void Setup()
    {
        player = FindObjectOfType<PlayerInterface>().gameObject;
    }
    public abstract void Activate(PlayerInterface player);
    public abstract void Deactivate(PlayerInterface player);
    public abstract void Input(PlayerInterface player);

    public virtual bool isInteractable()
    {
        return Vector2.Distance(transform.position, player.transform.position)<activationDistance;
    }
    public override void Interact(PlayerInterface playerInterface)
    {
         if(!busy)
         {
            Activate(playerInterface);
         }
         else
         {
            Deactivate(playerInterface);
         }
    }
}
