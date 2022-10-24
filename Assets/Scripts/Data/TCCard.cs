using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public partial class TCCard : TCNode
{
    public static Dictionary<string, int> keys;
    public static Dictionary<int, string> values;

    public enum Type
    {
        Attack,
        Move,
        Skill,
        Power,
        Status
    }

    public int id;
    public string key, displayName, displayNote;
    public Sprite background, icon;
    public static Sprite[] backgrounds, icons;
    public Type type;
    public int cost;
    public int value;
    public int range;

    public TCUnit source;
    public TCUnit target;

    void Start() 
    {
        
    }

    public static TCCard Create(int id)
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/TCCard");
        GameObject cardObj = Instantiate(cardPrefab);
        TCCard card = cardObj.GetComponent<TCCard>();
        Deserialize(values[id], card);
        return card;
    }

    public void ExcuteEffect(TCGrid selectedGrid)
    {
        //Debug.Log(id);
        if(this.id == 1)
        {
            if(selectedGrid.unit != null)
            {
                selectedGrid.unit.hp -= this.value;
                Debug.Log("MaxHp:" + selectedGrid.unit.maxHP + " CurrentHP:" + selectedGrid.unit.hp);
            }
        }
        else if(this.id == 2)
        {
            this.source = TCBattleSystem.instance.playerUnits[0];
            Debug.Log(this.source.name);
            this.source.grid.Clear();
            selectedGrid.Accept(this.source);
        }
    }

    public static TCCard Deserialize(string s, TCCard ret)
    {
        string[] ss = s.Split(',');
        ret.key = ss[keys["Key"]];
        ret.id = int.Parse(ss[keys["ID"]]);
        ret.displayName = ss[keys["Name"]];
        ret.type = DeserializeType(ss[keys["Type"]]);
        ret.cost = int.Parse(ss[keys["Cost"]]);
        ret.displayNote = ss[keys["Note"]];
        int.TryParse(ss[keys["Range"]], out ret.range);
        ret.ConfigUI();
        return ret;
    }

    public static Type DeserializeType(string s)
    {
        Type ret;
        switch(s)
        {
            case "1":
            ret = Type.Attack;
            break;
            case "2":
            ret = Type.Skill;
            break;
            case "3":
            ret = Type.Move;
            break;
            case "4":
            ret = Type.Power;
            break;
            default:
            ret = Type.Move;
            break;
        }
        return ret;
    }

    public void ConfigUI()
    {
        switch(type)
        {
            case Type.Attack:
            this.background = backgrounds[7];
            this.icon = icons[0];
            break;
            case Type.Move:
            this.background = backgrounds[9];
            this.icon = icons[9];
            break;
            case Type.Skill:
            this.background = backgrounds[10];
            this.icon = icons[2];
            break;
            case Type.Power:
            this.background = backgrounds[6];
            this.icon = icons[6];
            break;
            default:
            break;
        }
        transform.Find("Background").GetComponent<Image>().sprite = this.background;
        transform.Find("Icon").GetComponent<Image>().sprite = this.icon;
        transform.Find("Name").GetComponent<Text>().text = this.displayName;
        transform.Find("Description").GetComponent<Text>().text = this.displayNote;
    }
}
