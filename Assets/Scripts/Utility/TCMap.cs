using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TCMap : TCNode
{
    public static TCMap instance;
    private void Awake()
    {
        instance = this;
    }
    public List<TCGrid>grids;

    public float row;
    public float col;

    void Start() 
    {
        grids = new List<TCGrid>();
        LoadGrid();
    }

    void LoadGrid()
    {
        float mapW = GetComponent<RectTransform>().rect.width;
        float mapH = GetComponent<RectTransform>().rect.height;

        int startX = -50;
        int startY = -50;

        row = mapW / 100;
        col = mapH / 100;

        for(int i = 1; i <= row; i++)
        {
            for(int j =1; j <= col; j++)
            {
                GameObject gridPrefab = Resources.Load("Prefabs/TCGrid") as GameObject;
                GameObject grid = Instantiate(gridPrefab);
                grid.transform.SetParent(this.transform);

                grid.name = "grid_(" + i + ", " + j + ")";
                
                float gridW = grid.GetComponent<RectTransform>().rect.width;
                float gridH = grid.GetComponent<RectTransform>().rect.height;

                float gridX = startX + i * gridW - (mapW / 2);
                float gridY = startY + j * gridH - (mapH / 2);



                grid.transform.localPosition = new Vector2(gridX, gridY);

                TCGrid g = grid.GetComponent<TCGrid>();
                grids.Add(g);
                g.x = i;
                g.y = j;
            }
        }
    }

    public TCGrid FindGridBy(int x, int y)
    {
        TCGrid ret = null;
        foreach(var grid in grids)
        {
            if(grid.x == x && grid.y == y)
            {
                ret = grid;
            }
        }
        //Debug.Log(ret);
        return ret;
    }

    public TCGrid FindGridByPointer(PointerEventData pointer)
    {
        TCGrid ret = null;
        foreach(var grid in grids)
        {
            if(grid.transform.position.x + 50 >= pointer.position.x && grid.transform.position.x - 50 <= pointer.position.x && grid.transform.position.y + 50 >= pointer.position.y && grid.transform.position.y - 50 <= pointer.position.y)
            {
                ret = grid;
            }
        }
        return ret;
    }

    public List<TCGrid> FindGridsWithinDistance(TCGrid centerGrid, int distance)
    {
        List<TCGrid> ret = new List<TCGrid>();
        foreach(var grid in grids)
        {
            if(Mathf.Abs(grid.x - centerGrid.x) <= distance && Mathf.Abs(grid.y - centerGrid.y) <= distance)
            {
                if(centerGrid.x == grid.x && centerGrid.y == grid.y)
                {
                    
                }
                else
                {
                    ret.Add(grid);
                }
            }
        }
        return ret;
    }
<<<<<<< Updated upstream
=======

    public void ClearGrids()
    {
        foreach(var grid in grids)
        {
            grid.Clear();
        }
    }
>>>>>>> Stashed changes
}
