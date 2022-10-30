using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCUnit : TCNode
{
    public static Dictionary<string, int> keys;
    public static Dictionary<int, string> values;
<<<<<<< Updated upstream
    public string key, note, displayName, spriteFilePath;
=======

    public enum TCUnitType
    {
        Player,
        Enemy
    }
    public string key, note, displayName, spriteFilePath;
    public TCUnitType type;
>>>>>>> Stashed changes
    public int value;
    public int id;
    public int maxHP;
    public int hp;
    public int maxAP;
    public int ap;
    public int atk;
    public int def;
<<<<<<< Updated upstream
=======
    public bool isDead;
>>>>>>> Stashed changes

    public Sprite sprite;
    //buff

    public TCGrid grid;

    public static TCUnit Create(int id)
    {
        GameObject unitPrefab = Resources.Load<GameObject>("Prefabs/TCUnit");
        GameObject unitObj = Instantiate(unitPrefab);

        TCUnit unit = unitObj.GetComponent<TCUnit>();
<<<<<<< Updated upstream
=======
        //Debug.Log(unit);
        //Debug.Log(values[id]);
>>>>>>> Stashed changes
        Deserialize(values[id], unit);

        //Sprite s = Resources.Load("Images/CHARACTERS/player/hero" + id) as Sprite;
        //unitObj.GetComponent<SpriteRenderer>().sprite = s;

        Sprite i = Resources.Load<Sprite>(unit.spriteFilePath);
        unitObj.GetComponent<Image>().sprite = i;

        return unit;
    }

        public static TCUnit Deserialize(string s, TCUnit ret)
    {
        string[] ss = s.Split(',');
        ret.key = ss[keys["Key"]];
<<<<<<< Updated upstream
=======
        ret.type = DeserializeType(ss[keys["Type"]]);
>>>>>>> Stashed changes
        ret.id = int.Parse(ss[keys["ID"]]);
        ret.displayName = ss[keys["Name"]];
        ret.note = ss[keys["Note"]];
        ret.maxHP = int.Parse(ss[keys["HP"]]);
        ret.atk = int.Parse(ss[keys["ATK"]]);
        ret.def = int.Parse(ss[keys["DEF"]]);
        ret.maxAP = int.Parse(ss[keys["AP"]]);
        ret.hp = ret.maxHP;
        ret.ap = ret.maxAP;
        ret.spriteFilePath = ss[keys["Sprite"]];
        //ret.ConfigUI();
        return ret;
    }
<<<<<<< Updated upstream
=======

    public static TCUnitType DeserializeType(string s)
    {
        TCUnitType ret;
        switch(s)
        {
            case "1":
            ret = TCUnitType.Player;
            break;
            case "2":
            ret = TCUnitType.Enemy;
            break;
            default:
            ret = TCUnitType.Enemy;
            break;
        }
        return ret;
    }

    void Update() 
    {
        if(this.hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log("Dead");
            isDead = true;
            switch(type)
            {
                case TCUnitType.Player:
                TCUnitsSystem.instance.playerUnits.Remove(this);
                if(TCUnitsSystem.instance.playerUnits.Count <= 0)
                {
                    TCBattleSystem.instance.Lose();
                }
                break;
                case TCUnitType.Enemy:
                TCUnitsSystem.instance.enemyUnits.Remove(this);
                if(TCUnitsSystem.instance.enemyUnits.Count <= 0)
                {
                    TCBattleSystem.instance.Win();
                }
                break;
                default:
                TCUnitsSystem.instance.playerUnits.Remove(this);
                if(TCUnitsSystem.instance.playerUnits.Count <= 0)
                {
                    TCBattleSystem.instance.Lose();
                }
                break;
            }
            Debug.Log(TCUnitsSystem.instance.enemyUnits.Count);
            Destroy(gameObject);
    }

    public void ClearUnit()
    {
        Destroy(gameObject);
    }
>>>>>>> Stashed changes
}
