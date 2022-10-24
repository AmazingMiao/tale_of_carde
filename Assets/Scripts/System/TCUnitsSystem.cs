using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCUnitsSystem : MonoBehaviour
{
    public static TCUnitsSystem instance;
    private void Awake()
    {
        instance = this;
    }
    public List<TCUnit> playerUnits;
    public List<TCUnit> enemyUnits;
    public void LoadUnits()
    {
        TCUnit playerUnit1 = TCUnit.Create(1);
        TCGrid grid1 = TCMap.instance.FindGridBy(1, 1);
        grid1.Accept(playerUnit1);
        playerUnits.Add(playerUnit1);

        TCUnit enemyUnit1 = TCUnit.Create(5);
        TCGrid grid2 = TCMap.instance.FindGridBy(9, 9);
        grid2.Accept(enemyUnit1);
        enemyUnits.Add(enemyUnit1);

        TCUnit enemyUnit2 = TCUnit.Create(5);
        TCGrid grid3 = TCMap.instance.FindGridBy(8, 9);
        grid3.Accept(enemyUnit2);
        enemyUnits.Add(enemyUnit2);
    }
}
