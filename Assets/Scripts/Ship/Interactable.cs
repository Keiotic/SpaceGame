using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactionDistance = 4;
    public abstract void Interact(PlayerInterface playerInterface);
}
