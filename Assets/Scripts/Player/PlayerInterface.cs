using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerController))]
public class PlayerInterface : MonoBehaviour
{
    ShipInterface connectedInterface;
    TopDownPlayerController controller;
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
}
