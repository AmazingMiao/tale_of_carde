using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCCard : MonoBehaviour
{
    public enum Type
    {
        Attack,
        Move,
        Skill,
        Power,
        Status
    }

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

    public virtual void ExcuteEffect()
    {
        
    }
}
