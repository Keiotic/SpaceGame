using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerController))]
public class PlayerInterface : MonoBehaviour
{
    ShipInterface connectedInterface;
    TopDownPlayerController controller;
    List<Interactable> interactables = new List<Interactable>();
    void Start()
    {
        controller = GetComponent<TopDownPlayerController>();
    }

    void Update()
    {
        
    }

    public void Interact()
    {

    }

    public void SetShipInterface (ShipInterface sInterface)
    {
        connectedInterface = sInterface;
        if(connectedInterface != null)
        {
            controller.SetMobility(false);
        }
        else
        {
            controller.SetMobility(true);
        }
    }

    public void AddToInteractableQueue(Interactable element)
    {
        interactables.Add(element);
    }
    public void RemoveFromInteractableQueue(Interactable element)
    {
        interactables.Remove(element);
    }
}
