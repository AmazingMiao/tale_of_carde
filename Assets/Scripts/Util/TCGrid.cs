using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCGrid : TCNode
{
    public Text textID;


    public TCUnit unit;

    public int x;
    public int y;


    public void Accept(TCUnit unit)
    {
        if(this.unit != null)
        {
            return;
        }

        this.unit = unit;
        unit.transform.SetParent(this.transform);
        unit.transform.localPosition = Vector2.zero;
    }

    public void Reload()
    {

    }

    public void Clear()
    {

    }

}
