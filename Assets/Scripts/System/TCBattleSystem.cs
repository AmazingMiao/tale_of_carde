using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCBattleSystem : MonoBehaviour
{
    public GameObject unitPrefab;
    public GameObject cardPrefab;



    public static TCBattleSystem instance;
    
    private void Awake()
    {
        instance = this;
    }



    public TCMap map;

    public List<TCUnit> playerUnits;
    public List<TCUnit> enemyUnits;


    //Manage Cards
    public GameObject hand;
    public GameObject deck;
    public GameObject used;



    public TCUnit source;
    public TCUnit target;
    public TCCard card;






    // Start is called before the first frame update
    void Start()
    {
        //LoadMap();
        //LoadLevel();
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

        LoadDeck();
    }


    public void LoadDeck()
    {
        float startX = 10f;
        for(int i =0;i<4;i++)
        {
            GameObject obj = Instantiate(cardPrefab) as GameObject;
            TCCard card = obj.GetComponent<TCCard>();

            card.textName.text = "card_" + i;
            obj.gameObject.transform.SetParent(hand.transform);
            obj.transform.localPosition = new Vector2(startX + i * 100, 0);

        }
    }




    public void PlayCard(TCCard card)
    {
        this.card = card;
        card.ExcuteEffect(playerUnits[0], enemyUnits[0]);
        Debug.Log("PlayCard: " + card.name);
    }




}
