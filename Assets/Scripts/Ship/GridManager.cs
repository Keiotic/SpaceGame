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
        for(int col = 0; col < cols; col++)
        {
            List<GameObject> subgrid = new List<GameObject>();
            for(int row = 0; row < rows; row++)
            {
                GameObject tile = (GameObject)Instantiate(gridRef, transform);
                Vector3 pos = new Vector3();
                pos.x = (-rows+1)*tileSize/2 + row * tileSize;
                pos.y = (-cols+1)*tileSize/2 + col * tileSize;
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
        Vector2 mousePositionInGrid = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInGrid /= tileSize;
        mousePositionInGrid.x = Mathf.RoundToInt(mousePositionInGrid.x) + Mathf.Floor(cols / 2);
        mousePositionInGrid.y = Mathf.RoundToInt(mousePositionInGrid.y) + Mathf.Floor(rows / 2);

        return mousePositionInGrid;
    }

    public Vector2 GetMouseToGridWorldPosition ()
    {
        Vector2 mousePos = GetMousePositionInGrid();
        return GetWorldPositionFromGrid(mousePos);
    }

    public Vector2 GetWorldPositionFromGrid(Vector2 gridposition)
    {
        Vector2 position = gridposition*tileSize;
        position.x -= (cols-1)/2*tileSize;
        position.y -= (rows-1)/2*tileSize;
        return position;
    }

    public bool VectorIsInGrid (Vector2 input)
    {
        if(Mathf.Abs(input.x - rows / 2) <= rows / 2 &&Mathf.Abs(input.y - cols / 2) <= cols / 2)
        {
            return true;
        }
        return false;
    }

    public float GetCellSize ()
    {
        return tileSize;
    }
}
