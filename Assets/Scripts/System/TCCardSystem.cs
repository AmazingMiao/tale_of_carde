using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TCCardSystem : MonoBehaviour
{
    public static TCCardSystem instance;
    private void Awake()
    {
        instance = this;
        hands = new List<TCCard>();
        drawPile = new List<TCCard>();
        discardPile = new List<TCCard>();
    }
<<<<<<< Updated upstream
=======

    public List<TCCard> deck;
>>>>>>> Stashed changes
    public List<TCCard> hands;
    public List<TCCard> drawPile;
    public List<TCCard> discardPile;

    public Text drawPileNum;
    public Text discardPileNum;
<<<<<<< Updated upstream
    void Start()
    {
        UpdateUI();
=======
    public GameObject cardSelectingPanel;
    public GameObject selectCardButton;
    void Start()
    {
        UpdateUI();
        for(int i=0; i<20; i++)
        {
            TCCard card = TCCard.Create(Random.Range(1, 3)); //TCCard.values.Count
            //Debug.Log("card");
            TCCardSystem.instance.deck.Add(card);
        }
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< Updated upstream
=======
    public void LoadDrawPile()
    {
        drawPile = new List<TCCard>();
        foreach(var card in deck)
        {
            TCCard c = TCCard.Create(card.id);
            drawPile.Add(c);
        }
        ShuffleDrawPile();
        Debug.Log(drawPile.Count);
        UpdateUI();
    }

>>>>>>> Stashed changes
    public void Draw()
    {
        if(drawPile.Count == 0)
        {
            Shuffle();
        }
        TCCard card1 = drawPile[0];
        hands.Add(card1);
        card1.transform.SetParent(this.transform);
        drawPile.Remove(card1);
        UpdateUI();
    }

    public void Play(TCCard card)
    {
        hands.Remove(card);
        discardPile.Add(card);
        UpdateUI();
    }

    public void DiscardAllHands()
    {
        foreach(var card in hands)
        {
            discardPile.Add(card);
        }
        hands = new List<TCCard>();
        UpdateUI();
    }

    public void Shuffle()
    {
        foreach(var card in discardPile)
        {
            drawPile.Add(card);
        }
        discardPile = new List<TCCard>();
        ShuffleDrawPile();
        UpdateUI();
    }

    public void ShuffleDrawPile()
    {
        List<TCCard> newDrawPile = new List<TCCard>();
        while(drawPile.Count > 0)
        {
            int r = Random.Range(0, drawPile.Count);
            newDrawPile.Add(drawPile[r]);
            drawPile.Remove(drawPile[r]);
        }
        drawPile = newDrawPile;
    }

<<<<<<< Updated upstream
=======
    public void CreateRewardCard()
    {
        cardSelectingPanel.gameObject.SetActive(true);
        for(int i=0; i<3; i++)
        {
            TCCard card = TCCard.Create(Random.Range(1, 3));
            card.isReward = true;
            card.transform.SetParent(cardSelectingPanel.transform);
            card.gameObject.transform.localPosition = new Vector2(-250 + (i * 250), 0);
        }
    }

    public void ClearCards()
    {
        foreach(var card in hands)
        {
            card.ClearCard();
        }
        foreach(var card in drawPile)
        {
            card.ClearCard();
        }
        foreach(var card in discardPile)
        {
            card.ClearCard();
        }
        drawPile = new List<TCCard>();
        discardPile = new List<TCCard>();
        hands = new List<TCCard>();
        UpdateUI();
    }

>>>>>>> Stashed changes
    public void UpdateUI()
    {
        int i = 0;
        float w = 750;
        float h = 500;
        //Debug.Log(hands.Count);
        foreach(var card in hands)
        {
            //Debug.Log(card);
            card.gameObject.transform.localPosition = new Vector2(((i%4) * (w/4))- (w/2) + (w/8), (h/4) - ((i/4) * (h/2)));
            i++;
            //Debug.Log("i="+i);
        }
        foreach(var card in drawPile)
        {
            //Debug.Log(card);
            card.gameObject.transform.localPosition = new Vector2(-1800, 290);
            i++;
            //Debug.Log("i="+i);
        }
        foreach(var card in discardPile)
        {
            //Debug.Log(card);
            card.gameObject.transform.localPosition = new Vector2(-1500, 290);
            i++;
            //Debug.Log("i="+i);
<<<<<<< Updated upstream
=======
        }
        foreach(var card in deck)
        {
            //Debug.Log(card);
            card.gameObject.transform.localPosition = new Vector2(-1800, 290);
            i++;
            //Debug.Log("i="+i);
>>>>>>> Stashed changes
        }              
        drawPileNum.text = drawPile.Count + "";
        discardPileNum.text = discardPile.Count + "";
    }
}
