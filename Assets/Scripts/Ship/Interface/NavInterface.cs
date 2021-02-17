using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavInterface : ShipInterface
{
    public List<Engine> engines;
    public Rigidbody2D rig;

    public override void Initialize(SpaceShipHandler handler)
    {
        base.Initialize(handler);
        this.engines = handler.GetEngines();
        this.rig = handler.rig;
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


    public override void Activate(PlayerInterface player)
    {
        connectedPlayer = player;
        player.SetShipInterface(this);
        busy = true;
        print("Activate");
    }

    public override void Deactivate(PlayerInterface player)
    {
        connectedPlayer = null;
        player.SetShipInterface(null);
        busy = false;
        print("DeActivate");
    }

    public override void Input(PlayerInterface player, Vector2 movement, bool firing)
    {
        if (movement.y > 0)
        {
            for (int i = 0; i < engines.Count; i++) {

                if (engines[i].HasThrust())
                {
                    rig.AddForce(handler.transform.up * engines[i].GetThrust());
                    engines[i].Fire();
                }
            }
        }
        if(movement.x != 0)
        {

      
            for (int i = 0; i < engines.Count; i++)
            {

                if (engines[i].HasThrust())
                {
                    rig.AddTorque(-movement.x*engines[i].torqueForce);
                    engines[i].Fire();
                }
            }
        }
    }



    public override void Interact(PlayerInterface playerInterface)
    {
         if(connectedPlayer == null)
         Activate(playerInterface);
         else if(connectedPlayer == playerInterface)
         {
            Deactivate(playerInterface);
         }
    }

}
