using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCCard_NormalAttack : TCCard
{

    public override void LoadData()
    {
        type = TCCard.Type.Attack;
        cost = 1;
    }


    public override void ExecuteEffect()
    {
        target.hp -= 1;
    }

}
