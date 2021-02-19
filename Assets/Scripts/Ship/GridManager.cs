using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10;
    public int cols = 10;
    public float tileSize = 1;
    public GameObject gridRef;

    List<List<GameObject>> grid = new List<List<GameObject>>();
    public void Initialize()
    {
        GenerateGrid();
    }

    public List<List<GameObject>> GenerateGrid()
    {
        for(int row = 0; row < rows; row++)
        {
            List<GameObject> subgrid = new List<GameObject>();
            for(int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(gridRef, transform);
                Vector3 pos = new Vector3();
                pos.x = (-rows+1)*tileSize/2 + row * tileSize;
                pos.y = (-cols+1)*tileSize /2 + col * tileSize;
                tile.transform.position = pos;
                subgrid.Add(tile);
            }
            grid.Add(subgrid);
        }
        return grid;
    }

    public void SetCellColor (Vector2 pos, Color color)
    {
        
    }

    public Vector2 GetMousePositionInGrid ()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInWorld /= tileSize;
        mousePositionInWorld.x = Mathf.RoundToInt(mousePositionInWorld.x);
        mousePositionInWorld.y = Mathf.RoundToInt(mousePositionInWorld.y);
        return mousePositionInWorld;
    }

    public bool VectorIsInGrid (Vector2 input)
    {
        if(Mathf.Abs(input.x)<=rows/2&&Mathf.Abs(input.y) <= cols / 2)
        {
            return true;
        }
        return false;
    }
}
