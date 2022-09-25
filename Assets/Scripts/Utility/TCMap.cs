using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCMap : TCNode
{

    List<TCGrid> grids;

    public int row;
    public int col;


    // Start is called before the first frame update
    void Start()
    {
        grids = new List<TCGrid>();
        row = 9;
        col = 9;
        LoadGrids();
    }


    public void LoadGrids()
    {
        for(int i = 0; i < row; i++)
        {
            for (int j= 0;j < col;j++)
            {
                GameObject gridPrefab = Resources.Load("Prefabs/TCGrid") as GameObject;

                GameObject grid = Instantiate(gridPrefab);
                grid.name = "grid" + i + "_" + j;
                grid.transform.SetParent(this.transform);
                

                float startX = 50f;
                float startY = 50f;

                float w = grid.GetComponent<RectTransform>().rect.width;
                float h = grid.GetComponent<RectTransform>().rect.height;

                //Debug.Log("w: " + w + " h: " + h);


                float x = startX + i * w - 450;
                float y = startY + j * h - 450;

                grid.transform.localPosition = new Vector2(x, y);

                TCGrid g = grid.GetComponent<TCGrid>();
                grids.Add(g);
                g.x = i;
                g.y = j;
                g.textID.text = "(" + g.x + ", " + g.y + ")";
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

        return ret;
    }



}
