using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCUnit : TCNode
{
    public int id;
    public int maxHP;
    public int hp;
    public int maxAP;
    public int ap;
    public int def;
    //buff

    public virtual void LoadData()
    {

    }

    public static TCUnit Create(int id)
    {
        GameObject unitPrefab = Resources.Load("Prefabs/TCunit") as GameObject;
        GameObject unitObj = Instantiate(unitPrefab);

        TCUnit ret = unitObj.GetComponent<TCUnit>();
        ret.id = id;

        Sprite s = Resources.Load("Images/CHARACTERS/players/hero" + id) as Sprite;
        unitObj.GetComponent<SpriteRenderer>().sprite = s;

        ret.LoadData();

        Debug.Log("2");

        return ret;
    }
}
