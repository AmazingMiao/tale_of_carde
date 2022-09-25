using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCCard_NormalAttack : TCCard
{

    public override void LoadData()
    {
        type = TCCardType.Attack;
        cost = 1;
    }



    public override void ExcuteEffect(TCUnit source, TCUnit target)
    {
        target.hp -= 1;
    }

}
