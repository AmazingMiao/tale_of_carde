using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TCCard : TCNode, IPointerClickHandler
{

    public Text textName;
    public Text textNote;
    public Image icon;


    public int id;
    public TCCardType type;
    public int cost;



    public virtual void LoadData()
    {
        if(this.id == 1)
        {
            this.icon.sprite = Resources.Load<Sprite>("Images/Cards/Attack1");
        }
        else if (this.id == 2)
        {
            this.icon.sprite = Resources.Load<Sprite>("Images/Cards/Armor");
        }
        else if (this.id == 3)
        {
            this.icon.sprite = Resources.Load<Sprite>("Images/Cards/BootsOfSpeed");
        }
        else 
        {
            Debug.LogWarning("TCCard LoadData: " + id);
        }

    }


    public virtual void ExcuteEffect(TCUnit source, TCUnit target)
    {
        
    }


    public static TCCard Create(int id)
    {
        GameObject cardPrefab = Resources.Load("Prefabs/TCCard") as GameObject;
        GameObject cardObj = Instantiate(cardPrefab);
        cardObj.name = "Card_" + id;

        TCCard ret = cardObj.GetComponent<TCCard>();
        ret.id = id;
        ret.LoadData();


        return ret;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TCBattleSystem.instance.PlayCard(this);
        Destroy(this.gameObject);
    }


}
