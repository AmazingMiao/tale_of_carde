using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCMap : TCNode
{
    public static TCMap instance;
    private void Awake()
    {
        instance = this;
    }
    List<TCGrid>grids;

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
        Debug.Log(ret);
        return ret;
    }
}
