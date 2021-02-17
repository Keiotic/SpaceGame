using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactionDistance;
    public bool inRange;
    public abstract void Interact(PlayerInterface playerInterface);
    public abstract bool IsInteractable(PlayerInterface playerInterface);
    public abstract void PlayerDeath(PlayerInterface playerInterface);
}
