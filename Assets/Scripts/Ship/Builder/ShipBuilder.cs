using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBuilder : MonoBehaviour
{
    public ShipComponents componentHolder;
    private List<ShipComponent> selectedShipParts;
    private GridManager grid;
    private ShipComponent selectedTool;
    private Button selectedToolButton;
    public GameObject toolButtonPrefab;
    public GameObject toolContainer;
    private List<Button> toolbuttons = new List<Button>();
    public ButtonColors buttonColors;


    [System.Serializable]
    public class ButtonColors
    {
        [Header("Unselected element")]
        public ColorBlock unselected;
        [Header("Selected element")]
        public ColorBlock selected;
    }
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
            selectedShipParts = populateType;
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
            Button button = GameObject.Instantiate(toolButtonPrefab).GetComponent<Button>();
            button.transform.parent = toolContainer.transform;
            button.transform.GetChild(0).GetComponent<Text>().text = comp.displayname;
            button.onClick.AddListener(delegate {SetActiveTool(comp, button);});
            
            toolbuttons.Add(button);
        }
    }

    public void SetActiveTool (ShipComponent component, Button button)
    {
        if(component == selectedTool)
        {
            selectedToolButton.colors = buttonColors.unselected;
            selectedTool = null;
            selectedToolButton = null;
        }
        else
        {
            selectedTool = component;
            selectedToolButton = button;
            button.colors = buttonColors.selected;
        }
    }
}
