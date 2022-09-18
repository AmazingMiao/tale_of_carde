using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCCard : MonoBehaviour
{

    public enum Type
    {
        Attack,
        Skill,
        Ability,
        Status,
        Curse
    }


    public Type type;
    public int cost;

    public TCUnit source;
    public TCUnit target;


    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }
    

    public virtual void LoadData()
    {

    }


    public virtual void ExecuteEffect()
    {

    }



}
