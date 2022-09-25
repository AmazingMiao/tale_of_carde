using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCUnit_Knight : TCUnit
{
    
    public override void LoadData()
    {
        base.LoadData();
        maxHP = 50;
        hp = 50;
        maxAP = 3;
        ap = 3;
        def = 0;
    }

}
