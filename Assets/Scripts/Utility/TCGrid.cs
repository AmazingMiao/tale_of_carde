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

<<<<<<< Updated upstream
    public void Accept(TCUnit unit)
    {
        if(this.unit != null)
        {
            return;
=======
    public bool Accept(TCUnit unit)
    {
        if(this.unit != null)
        {
            return false;
>>>>>>> Stashed changes
        }

        this.unit = unit;
        this.unit.grid = this;
        unit.transform.SetParent(this.transform);
        unit.transform.localPosition = Vector2.zero;
<<<<<<< Updated upstream
=======
        return true;
>>>>>>> Stashed changes
    }

    public void Reload()
    {

    }

    public void Clear()
    {
<<<<<<< Updated upstream
        this.unit.grid = null;
        this.unit = null;
=======
        if(this.unit != null)
        {
            this.unit.grid = null;
            this.unit = null;
        }
        this.EnterState(TCGridState.Normal);
>>>>>>> Stashed changes
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
