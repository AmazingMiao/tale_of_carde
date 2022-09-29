using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCBattleSystem : MonoBehaviour
{
    public static TCBattleSystem instance;
    private void Awake()
    {
        instance = this;
    }

    public Button mainButton;

    //public TCMap map;

    public List<TCUnit> playerUnits;
    public List<TCUnit> enemyUnits;

    public TCUnit source;
    public TCUnit target;
    public TCCard card;

    public TCBattleState state;

    void Start() 
    {
        mainButton = GetComponentInChildren<Button>();
        LoadLevel();
        //map = GameObject.Find("TCMap").GetComponent<TCMap>();
    }

    public void LoadMap()
    {

    }

    public void LoadLevel()
    {
        TCUnit playerUnit1 = TCUnit.Create(1);
        TCGrid grid1 = TCMap.instance.FindGridBy(1, 1);
        grid1.Accept(playerUnit1);
        playerUnits.Add(playerUnit1);

        TCUnit enemyUnit1 = TCUnit.Create(2);
        TCGrid grid2 = TCMap.instance.FindGridBy(9, 9);
        grid2.Accept(enemyUnit1);
        enemyUnits.Add(enemyUnit1);

        Debug.Log(grid1);
        Debug.Log(playerUnit1);
    }
}
