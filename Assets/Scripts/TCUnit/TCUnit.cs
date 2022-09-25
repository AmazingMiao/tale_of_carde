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



    public static TCUnit Create(int id)
    {
        Debug.Log("-----TCUnit-----");
        //GameObject unitPrefab = Resources.Load("TCUnit") as GameObject;
        GameObject obj = Instantiate(TCBattleSystem.instance.unitPrefab);
        Debug.Log(obj);

        TCUnit ret = obj.GetComponent<TCUnit>();
        Debug.Log(ret);

        Sprite s = Resources.Load("Hero/hero" + id) as Sprite;
        obj.GetComponent<SpriteRenderer>().sprite = s;
        Debug.Log(s);

        ret.id = id;
        return ret;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TCBattleSystem.instance.source = this;
    }

}
