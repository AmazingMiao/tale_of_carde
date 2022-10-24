using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCDataManager : MonoBehaviour
{

    public static TCDataManager Instance;


    private void Awake()
    {
        Instance = this;

        TCCard.backgrounds = Resources.LoadAll<Sprite>("Images/Cards");
        TCCard.icons = Resources.LoadAll<Sprite>("Images/Details");

        //string[] skillData = TCDataManager.ReadFile("Data/InnPC - Skill");
        //string[] levelData = TCDataManager.ReadFile("Data/InnPC - Level");
        //string[] itemData = TCDataManager.ReadFile("Data/InnPC - Item");
        string[] cardData = TCDataManager.ReadFile("Data/tale_of_carde_cards");
        string[] unitData = TCDataManager.ReadFile("Data/tale_of_carde_units");

        //Deserialize(skillData, out TCSkill.allKeys, out TCSkill.allValues);
        //Deserialize(unitData, out TCUnit.allKeys, out TCUnit.allValues);
        //Deserialize(levelData, out TCLevel.allKeys, out TCLevel.allValues);
        //Deserialize(itemData, out TCItem.allKeys, out TCItem.allValues);
        Deserialize(cardData, out TCCard.keys, out TCCard.values);
        Deserialize(unitData, out TCCard.keys, out TCCard.values);
        
    }


    void Start()
    {
        
        //TCSkill.Init();
        //TCUnit.Init();
        //TCItem.Init();
    }


    public static string[] ReadFile(string f)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(f);
        string[] lines = textAsset.text.Split('\n');
        return lines;
    }
    

    public static void Deserialize(string[] ss, out Dictionary<string, int> allKeys, out Dictionary<int, string> allValues)
    {
        allKeys = new Dictionary<string, int>();
        allValues = new Dictionary<int, string>();

        int index = 0;
        foreach (var s in ss)
        {
            string[] values = s.Split(',');

            if (values[0] == null || values[0] == "")
            {
                continue;
            }

            if (index == 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == "End")
                    {
                        break;
                    }
                    allKeys.Add(values[i], i);
                }
            }
            else
            {
                int id = int.Parse(values[allKeys["ID"]]);
                allValues.Add(id, s);
            }
            index++;
        }
    }


}
