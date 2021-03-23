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

    [SerializeField]
    private List<FlipCard> cardsInPlay = new List<FlipCard>();

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
    }

    public void InitializeCardsInPlay()
    {
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
