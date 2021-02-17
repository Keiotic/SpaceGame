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
    public GameObject toolButton;
    public GameObject toolContainer;
    private List<Button> toolbuttons = new List<Button>();
    public enum ComponentType
    {
        none,
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

    public void SelectComponentMenu (int componentType)
    {
        ComponentType type = (ComponentType)componentType;
        if (type == currentComponent||type == ComponentType.none)
        {
            currentComponent = ComponentType.none;
            ClearButtons();
        }
        else
        {
            currentComponent = type;
            ClearButtons();
            List<ShipComponent> populateType = new List<ShipComponent>();
            switch (type)
            {
                case ComponentType.room:
                    populateType = new List<ShipComponent>(componentHolder.rooms);
                    break;
                case ComponentType.weapon:
                    populateType = new List<ShipComponent>(componentHolder.weapons);
                    break;
                case ComponentType.shield:
                    populateType = new List<ShipComponent>(componentHolder.shields);
                    break;
                case ComponentType.engine:
                    populateType = new List<ShipComponent>();
                    break;
            }
            PopulateButtons(populateType);
        }
    }

    public void ClearButtons ()
    {
        for(int i = toolbuttons.Count-1; i >= 0; i--)
        {
            Destroy(toolbuttons[i].gameObject);
        }
        toolbuttons.Clear();
    }

    public void PopulateButtons (List<ShipComponent> list)
    {
        foreach(ShipComponent comp in list)
        {
            Button button = GameObject.Instantiate(toolButton).GetComponent<Button>();
            button.transform.parent = toolContainer.transform;
            button.transform.GetChild(0).GetComponent<Text>().text = comp.displayname;
            toolbuttons.Add(button);
        }
    }

}
