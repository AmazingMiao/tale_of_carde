using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TCUnit : TCNode, IPointerClickHandler
{
    
    public Image icon;

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
        
        GameObject unitPrefab = Resources.Load("Prefabs/TCUnit") as GameObject;
        GameObject unitObj = Instantiate(unitPrefab);

        TCUnit ret = unitObj.GetComponent<TCUnit>();
        ret.id = id;

        Sprite s = Resources.Load("Image/Hero/hero" + id) as Sprite;
        unitObj.GetComponent<SpriteRenderer>().sprite = s;

        ret.LoadData();

        return ret;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TCBattleSystem.instance.source = this;
    }

}
