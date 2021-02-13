using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerController))]
public class PlayerInterface : MonoBehaviour
{
    ShipInterface connectedInterface;
    TopDownPlayerController controller;
    public List<Interactable> interactables = new List<Interactable>(); //Should ideally be switched for a LinkedList or other more efficient insertion/removal data structure
    void Start()
    {
        controller = GetComponent<TopDownPlayerController>();
    }

    void Update()
    {
        for(int i = interactables.Count - 1; i >= 0; i--)
        {
            if(!interactables[i])
            {
                interactables.RemoveAt(i);
            }
        }
        if(Input.GetButtonDown("Interact"))
        {
            Interact();
        }
        if(connectedInterface!=null)
        {
            Vector2 movementAxis = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.up;
            bool fireButtonPress = Input.GetButton("Fire");
        }
    }

    public void Interact()
    {
        Interactable closest = null;
        for (int i = interactables.Count - 1; i >= 0; i--)
        {
            if (closest == null || Vector2.Distance(interactables[i].transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position))
            {
                closest = interactables[i];
            }
        }
        if(closest)
        {
            closest.Interact(this);
        }
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
