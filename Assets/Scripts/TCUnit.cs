using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TCUnit : MonoBehaviour
{
    public int maxHP;
    public int hp;
    public int maxAP;
    public int ap;
    public int def;
    
    public List<TCBuff> buffs;
    

    private void Start()
    {
        LoadData();
    }


    public virtual void LoadData()
    {

    }
    

}
