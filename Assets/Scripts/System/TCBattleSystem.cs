using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    public PointerEventData selectingCard;

    void Start() 
    {
        mainButton = GetComponentInChildren<Button>();
        TCUnitsSystem.instance.LoadUnits();
        LoadDrawPile();
        state = TCBattleState.Begin;
        //map = GameObject.Find("TCMap").GetComponent<TCMap>();
    }

    public void LoadMap()
    {

    }

    // public void LoadLevel()
    // {
    //     TCUnit playerUnit1 = TCUnit.Create(1);
    //     TCGrid grid1 = TCMap.instance.FindGridBy(1, 1);
    //     grid1.Accept(playerUnit1);
    //     playerUnits.Add(playerUnit1);

    //     TCUnit enemyUnit1 = TCUnit.Create(2);
    //     TCGrid grid2 = TCMap.instance.FindGridBy(9, 9);
    //     grid2.Accept(enemyUnit1);
    //     enemyUnits.Add(enemyUnit1);

    //     TCUnit enemyUnit2 = TCUnit.Create(3);
    //     TCGrid grid3 = TCMap.instance.FindGridBy(8, 9);
    //     grid3.Accept(enemyUnit2);
    //     enemyUnits.Add(enemyUnit2);
    // }

    public void LoadDrawPile()
    {
        for(int i=0; i<20; i++)
        {
            TCCard card = TCCard.Create(Random.Range(1, TCCard.values.Count));
            TCCardSystem.instance.drawPile.Add(card);
        }
        Debug.Log(TCCardSystem.instance.drawPile.Count);
        TCCardSystem.instance.UpdateUI();
    }

    public void DrawCard()
    {
        for(int i=0; i<8; i++)
        {
            TCCardSystem.instance.Draw();
        }
    }

    public void EnterState(TCBattleState state)
    {
        this.state = state;
        switch(state)
        {
            case TCBattleState.PlayerRound:
            DrawCard();
            break;
            case TCBattleState.EnemyRound:
            TCCardSystem.instance.DiscardAllHands();
            Invoke("OnClick", 1);
            break;
            default:
            break;
        }
    }

    public void OnClick()
    {
        if(this.state == TCBattleState.Begin)
        {
            EnterState(TCBattleState.PlayerRound);
            mainButton.GetComponentInChildren<Text>().text = "End Turn";
        }
        else if(this.state == TCBattleState.PlayerRound)
        {
            EnterState(TCBattleState.EnemyRound);
            mainButton.interactable = false;
        }
        else if(this.state == TCBattleState.EnemyRound)
        {
            EnterState(TCBattleState.PlayerRound);
            mainButton.interactable = true;
        }
    }
}
