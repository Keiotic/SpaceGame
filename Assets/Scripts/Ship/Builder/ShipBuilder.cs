using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBuilder : MonoBehaviour
{
    public ShipComponents componentHolder;
    public GameObject ghost;
    public GameObject toolButtonPrefab;
    public GameObject toolContainer;
    public ButtonColors buttonColors;

    private SpriteRenderer ghostRenderer;
    private List<Button> toolbuttons = new List<Button>();
    private List<ShipComponent> selectedShipParts;
    private GridManager grid;
    private ShipComponent selectedTool;
    private Button selectedToolButton;

    private ShipObject ship;
    private ShipObjectRepresentation representation;
    private class ShipObjectRepresentation
    {
        public List<List<ShipComponent_Room>> rooms;
        public List<List<ShipComponent_Mechanism>> mechanisms;
    }

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
        engine,
        exterior
    }
    ComponentType currentComponent;
    void Start()
    {
        grid = GetComponent<GridManager>();
        grid.Initialize();
        ghost = Instantiate(ghost);
        ghost.SetActive(false);
        ghostRenderer = ghost.GetComponent<SpriteRenderer>();
        ship = new ShipObject(grid.cols, grid.rows);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = grid.GetMousePositionInGrid();
        ghost.SetActive(grid.VectorIsInGrid(mousePos) && selectedTool != null);
        if (selectedTool != null)
        {
            Vector2 ghostPos = grid.GetMousePositionInGrid() * grid.GetCellSize();
            ghost.transform.position = ghostPos;
            if (Input.GetButtonDown("Fire"))
            {
                TryPlaceTool(mousePos);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            TryErase(mousePos);
        }
    }

    public void SelectComponentMenu(int componentType)
    {
        ComponentType type = (ComponentType)componentType;
        if (type == currentComponent || type == ComponentType.none)
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
                case ComponentType.exterior:
                    populateType = new List<ShipComponent>(componentHolder.exteriors);
                    break;
            }
            selectedShipParts = populateType;
            PopulateButtons(populateType);
        }
    }

    public void ClearButtons()
    {
        for (int i = toolbuttons.Count - 1; i >= 0; i--)
        {
            Destroy(toolbuttons[i].gameObject);
        }
        toolbuttons.Clear();
    }

    public void PopulateButtons(List<ShipComponent> list)
    {
        foreach (ShipComponent comp in list)
        {
            Button button = GameObject.Instantiate(toolButtonPrefab).GetComponent<Button>();
            button.transform.SetParent(toolContainer.transform);
            button.transform.GetChild(0).GetComponent<Text>().text = comp.displayname;
            button.onClick.AddListener(delegate { SetActiveTool(comp, button); });

            toolbuttons.Add(button);
        }
    }

    public void SetActiveTool(ShipComponent component, Button button)
    {
        if (component == selectedTool)
        {
            selectedToolButton.colors = buttonColors.unselected;
            selectedTool = null;
            selectedToolButton = null;
            ghost.SetActive(false);
            ghostRenderer.sprite = null;
        }
        else
        {
            selectedTool = component;
            selectedToolButton = button;
            button.colors = buttonColors.selected;

            Debug.Log(selectedTool.displayname);
            ghostRenderer.sprite = selectedTool.inner.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void TryPlaceTool(Vector2 pos)
    {
        if (grid.VectorIsInGrid(pos))
        {
            if (selectedTool is ShipComponent_Room)
            {
                if (!LayerPosHasElement(ship.rooms, pos))
                {

                }
            }
            if (selectedTool is ShipComponent_Mechanism)
            {

            }
        }
    }

    public bool LayerPosHasElement<T>(List<List<T>> layer, Vector2 wantedposition)
    {
        if(layer[(int)wantedposition.x][(int)wantedposition.y]==null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public void TryErase(Vector2 pos)
    {
        if (grid.VectorIsInGrid(pos))
        {

        }
    }

}
