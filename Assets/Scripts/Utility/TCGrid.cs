using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TCGridState
{
    Normal,
    Red,
    Yellow,
    Purple,
    Green,
    Selected
}

public class TCGrid : TCNode
{
    public TCUnit unit;

    public TCGridState state;

    public int x;
    public int y;

    void Start() 
    {

    }

    public void Accept(TCUnit unit)
    {
        if(this.unit != null)
        {
            return;
        }

        this.unit = unit;
        this.unit.grid = this;
        unit.transform.SetParent(this.transform);
        unit.transform.localPosition = Vector2.zero;
    }

    public void Reload()
    {

    }

    public void Clear()
    {
        this.unit.grid = null;
        this.unit = null;
    }

    public void EnterState(TCGridState state)
    {
        this.state = state;
        switch(state)
        {
            case TCGridState.Normal:
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/TCGrid");
            break;
            case TCGridState.Selected:
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/TCGrid_Selected");
            break;
            case TCGridState.Green:
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/TCGrid_Green");
            //Debug.Log(higimg.GetComponent<Image>().sprite);
            break;
            case TCGridState.Red:
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/TCGrid_Red");
            break;
            default:
            break;
        }
    }
}
