using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBuilder : MonoBehaviour
{
    public ShipComponents componentHolder;
    public List<ShipComponent> activeShipParts;
    GridManager grid;
    public ShipComponent selectedTool;
    public enum ComponentType
    {
        room,
        weapon,
        shield,
        engine
    }
    ComponentType currentComponent;
    void Start()
    {
        grid = GetComponent<GridManager>();
        grid.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SelectComponentMenu (ComponentType type)
    {
        switch (type)
        {
            case ComponentType.room:
                
                break;
            case ComponentType.weapon:

                break;
            case ComponentType.shield:
                
                break;
            case ComponentType.engine:

                break;
        }
    }

    public void CreateButtons (List<ShipComponent> list)
    {
        List<Button> buttons = new List<Button>();
        foreach(ShipComponent comp : )
    }

}
