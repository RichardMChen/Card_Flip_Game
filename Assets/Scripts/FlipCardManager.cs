using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCardManager : MonoBehaviour
{
    // The total number of cards in play
    [Header("Total Number of Cards")]
    public int totalNumCardsInPlay = 2;

    public List<FlipCard> pickedCards = new List<FlipCard>();
    public int maxNumPickedCards = 2;   // The maximum number of cards the player can pick for a turn.
    public GameObject cardGroup;    // The game object that holds the cards for play.
    public GameObject cardPrefab;

    [SerializeField]
    private List<FlipCard> cardsInPlay = new List<FlipCard>();
    
    [SerializeField]
    private List<int> cardIDList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeCardsInPlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCardToList(FlipCard cardToAdd)
    {
        if (pickedCards.Count < maxNumPickedCards)
        {
            pickedCards.Add(cardToAdd);
        }

        // ************* Check if the cards match
        //bool isMatch = false;
        //if ()
        //{

        //}


    }

    public void InitializeCardsInPlay()
    {
        //List<int> cardIdList = new List<int>();
        for (int i = 0; i < totalNumCardsInPlay / 2; i++)
        {
            for (int y = 0; y < maxNumPickedCards; y++)
            {
                cardIDList.Add(i);
            }
        }

        for (int i = 0; i < totalNumCardsInPlay; i++)
        {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.SetParent(cardGroup.transform, false);
            int IDtoAssign = Random.Range(0, cardIDList.Count);
            newCard.GetComponent<FlipCard>().cardID = cardIDList[IDtoAssign];
            //newCard.GetComponent<FlipCard>().cardText.text = cardIDList[IDtoAssign].ToString();
            cardIDList.RemoveAt(IDtoAssign);
        }
        cardsInPlay.AddRange(cardGroup.GetComponentsInChildren<FlipCard>());
    }

    // Flips all remaining cards in play face down
    public void FlipCardsFaceDown()
    {
        //if (pickedCards.Count >= maxNumPickedCards)
        //{
            foreach (FlipCard card in cardsInPlay)
            {
                for (int i = 0; i < pickedCards.Count; i++)
                {
                    if (card == pickedCards[i])
                    {
                        card.FlipCardFaceDown();
                    }
                }
                card.gameObject.GetComponent<Button>().interactable = true;
            }
        //}

        pickedCards.Clear();
    }
    
    public int MaxNumPickedCards
    {
        get
        {
            return maxNumPickedCards;
        }
    }
}
