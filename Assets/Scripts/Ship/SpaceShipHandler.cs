using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipHandler : MonoBehaviour
{
    public List<Engine> engines;
    public Rigidbody2D rig;
    public List<GameObject> players;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public List<Engine> GetEngines ()
    {
        return engines;
    }
}
