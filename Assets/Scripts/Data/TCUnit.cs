using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCUnit : TCNode
{
    public static Dictionary<string, int> keys;
    public static Dictionary<int, string> values;
    public string key, note, displayName, spriteFilePath;
    public int value;
    public int id;
    public int maxHP;
    public int hp;
    public int maxAP;
    public int ap;
    public int atk;
    public int def;

    public Sprite sprite;
    //buff

    public TCGrid grid;

    public static TCUnit Create(int id)
    {
        GameObject unitPrefab = Resources.Load<GameObject>("Prefabs/TCUnit");
        GameObject unitObj = Instantiate(unitPrefab);

        TCUnit unit = unitObj.GetComponent<TCUnit>();
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
}
