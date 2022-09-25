using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCBattleSystem : MonoBehaviour
{

    //public GameObject unitPrefab;
    //public GameObject cardPrefab;
    //public GameObject gridPrefab;


    public static TCBattleSystem instance;
    
    private void Awake()
    {
        instance = this;
    }


    public Button mainButton;
    public Text noteText;


    public TCMap map;

    public List<TCUnit> playerUnits;
    public List<TCUnit> enemyUnits;


    //Manage Cards, Use CardSystem instead
    public GameObject hand;
    public GameObject deck;
    public GameObject used;

    

    public TCUnit source;
    public TCUnit target;
    public TCCard card;


    public TCBattleState state;


    void Start()
    {
        state = TCBattleState.Begin;

        mainButton = GameObject.Find("MainButton").GetComponentInChildren<Button>();
        mainButton.onClick.AddListener(OnClickMainButton);

        noteText = GameObject.Find("NoteText").GetComponentInChildren<Text>();
    }


    public void LoadMap()
    {

    }


    public void LoadLevel()
    {
        TCUnit playerUnit1 = TCUnit.Create(1);
        TCGrid grid1 = map.FindGridBy(0, 0);
        grid1.Accept(playerUnit1);
        playerUnits.Add(playerUnit1);


        TCUnit enemyUnit1 = TCUnit.Create(2);
        TCGrid grid2 = map.FindGridBy(8, 8);
        grid2.Accept(enemyUnit1);
        enemyUnits.Add(enemyUnit1);
    }


    public void LoadDeck()
    {
        //GameObject cardPrefab = Resources.Load("Prefabs/TCCard") as GameObject;
        float startX = -200f;
        for(int i = 1; i < 5; i++)
        {
            //GameObject obj = Instantiate(cardPrefab) as GameObject;
            //TCCard card = obj.GetComponent<TCCard>();

            TCCard card = TCCard.Create(i);

            card.textName.text = "card_" + i;
            card.gameObject.transform.SetParent(hand.transform);
            card.transform.localPosition = new Vector2(startX + i * 150, 0);

        }
    }


    public void OnClickMainButton()
    {
        if(state == TCBattleState.Begin)
        {
            LoadMap();
            LoadLevel();
            EnterState(TCBattleState.PlayerRound);
        }
        else if (state == TCBattleState.PlayerRound)
        {
            EnterState(TCBattleState.EnemyRound);
            Invoke("OnClickMainButton", 2);
        }
        else if (state == TCBattleState.EnemyRound)
        {
            EnterState(TCBattleState.PlayerRound);               
        }
    }




    public void EnterState(TCBattleState s)
    {
        state = s;
        switch(s)
        {
            case TCBattleState.Begin:
                mainButton.enabled = true;
                mainButton.GetComponentInChildren<Text>().text = "Start";
                ShowMessage("Battle Begin");
                break;
            case TCBattleState.PlayerRound:
                mainButton.enabled = true;
                mainButton.GetComponentInChildren<Text>().text = "End Turn";
                ShowMessage("PlayerRound");
                LoadDeck();
                break;
            case TCBattleState.EnemyRound:
                mainButton.enabled = false;
                mainButton.GetComponentInChildren<Text>().text = "Waiting...";
                ShowMessage("EnemyRound");
                DiscardHandCards();
                break;
            case TCBattleState.End:
                mainButton.enabled = false;
                mainButton.GetComponentInChildren<Text>().text = "Game Over";
                ShowMessage("GameOver");
                break;
        }
    }






    public void ShowMessage(string msg)
    {
        this.noteText.text = msg;
    }


    public void PlayCard(TCCard card)
    {
        this.card = card;
        card.ExcuteEffect(playerUnits[0], enemyUnits[0]);
        ShowMessage("PlayCard: " + card.name);
        
    }


    public void DiscardHandCards()
    {
        TCCard[] hands = GameObject.FindObjectsOfType<TCCard>();
        foreach (var card in hands)
        {
            Destroy(card.gameObject);
        }
    }



}
