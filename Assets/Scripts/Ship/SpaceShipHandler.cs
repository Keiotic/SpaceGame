using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipHandler : MonoBehaviour
{
    public List<Engine> engines;
    public Rigidbody2D rig;
    public List<GameObject> players;

    public GameObject ShipRepresentation;

    [System.Serializable]
    public class ModulePair
    {
        public GameObject playerSideObject;
        public GameObject shipSideObject;
        public int pairID;
    }

    public List<ModulePair> modules;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public List<Engine> GetEngines ()
    {
        return engines;
    }

}
