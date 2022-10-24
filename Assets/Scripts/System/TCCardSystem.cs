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
    public List<TCCard> hands;
    public List<TCCard> drawPile;
    public List<TCCard> discardPile;

    public Text drawPileNum;
    public Text discardPileNum;
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        }              
        drawPileNum.text = drawPile.Count + "";
        discardPileNum.text = discardPile.Count + "";
    }
}
