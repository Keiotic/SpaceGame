using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipInterface : Interactable
{
    public PlayerInterface connectedPlayer;
    public PlayerInterface playerInterface;
    protected bool busy;
    public SpaceShipHandler handler;

    public abstract void Activate(PlayerInterface player);
    public abstract void Deactivate(PlayerInterface player);
    public abstract void Input(PlayerInterface player, Vector2 movement, bool firing);

    public override bool IsInteractable(PlayerInterface playerInterface)
    {
        return Vector2.Distance(transform.position, playerInterface.transform.position) < interactionDistance;
    }
}
