using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCUnit_Knight : TCUnit
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        maxHP = 50;
        hp = 50;
        maxAP = 3;
        ap = 3;
        def = 0;
    }
}
