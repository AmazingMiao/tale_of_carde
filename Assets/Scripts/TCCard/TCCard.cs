using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TCCard : TCNode, IPointerClickHandler
{
    public enum Type
    {
        Attack,
        Move,
        Skill,
        Power,
        Status
    }


    public Text textName;
    public Text textNote;
    public Image icon;

    public Type type;
    public int cost;

    public TCUnit source;
    public TCUnit target;

    void Start() 
    {
        LoadData();
    }

    public virtual void LoadData()
    {

    }

    public virtual void ExcuteEffect(TCUnit source, TCUnit target)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TCBattleSystem.instance.PlayCard(this);
    }


}
