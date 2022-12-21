using UnityEngine;

public class CardManager : MonoBehaviour
{
    public bool isSinnerChoosing, isDevilChoosing;
    public bool isPlayed;
    GameManager gameManager;

    [Header("UI Part")]
    public GameObject cardPanel;

    [SerializeField] Transform[] cardSlots;

    [Header("Cards")]
    public Card[] cards;
    int cardNumber;

    [SerializeField] int openedCards = 0;
    [SerializeField] float randomValue;
    bool isSlot1Full, isSlot2Full, isSlot3Full;
    void Start()
    {
        cardPanel.SetActive(false);
        gameManager = GameObject.Find("GAME MANAGER").GetComponent<GameManager>();
    }
    void Update()
    {
        randomValue = Mathf.Clamp(randomValue, 0f, 100f);
        openedCards = Mathf.Clamp(openedCards, 0, 3);

        switch (openedCards)
        {
            case 0: break;
            case 1: if(!isSlot1Full)
                {
                    cards[cardNumber].transform.position = cardSlots[0].position;
                    isSlot1Full = true;
                } else
                {
                    cards[cardNumber].transform.position = cardSlots[1].position;
                }
                break;

            case 2:
                if (!isSlot2Full)
                {
                    isSlot2Full = true;
                    cards[cardNumber].transform.position = cardSlots[1].position;
                }
                else
                {
                    cards[cardNumber].transform.position = cardSlots[2].position;
                }
                break;

            case 3:
                if (!isSlot3Full)
                {
                    isSlot3Full = true;
                    cards[cardNumber].transform.position = cardSlots[2].position;
                } else
                {
                    cards[cardNumber].transform.position = cardSlots[0].position;
                }
                break;
        }
    }
    public void CardRaritySystem()
    {
        if (isSinnerChoosing && openedCards <= 3)
        {
            cardPanel.SetActive(true);
            randomValue = Random.value * 100f;

            //Open Random Cards
            cardNumber = Random.Range(0, cards.Length);
            if (randomValue <= 35)
            {
                if(cards[cardNumber].rarity == 35f)
                {
                    if (!cards[cardNumber].gameObject.activeSelf)
                    {
                        cards[cardNumber].gameObject.SetActive(true);
                        openedCards += 1;
                    }
                    else
                    {
                        while (cards[cardNumber].gameObject.activeSelf)
                        {
                            cardNumber = Random.Range(0, cards.Length); 
                        }
                    }
                } else
                {
                    while (cards[cardNumber].rarity != 35f)
                    {
                        cardNumber = Random.Range(0, cards.Length);
                    }
                }
            }
            else if (35 < randomValue && randomValue <= 60)
            {
                if (cards[cardNumber].rarity == 25f)
                {
                    if (!cards[cardNumber].gameObject.activeSelf)
                    {
                        cards[cardNumber].gameObject.SetActive(true);
                        openedCards += 1;
                    }
                    else
                    {
                        while (cards[cardNumber].gameObject.activeSelf)
                        {
                            cardNumber = Random.Range(0, cards.Length);
                        }
                    }
                } else
                {
                    while (cards[cardNumber].rarity != 35f)
                    {
                        cardNumber = Random.Range(0, cards.Length);
                    }
                }
            }
            else if (60 < randomValue && randomValue <= 80)
            {
                if (cards[cardNumber].rarity == 20f)
                {
                    if (!cards[cardNumber].gameObject.activeSelf)
                    {
                        cards[cardNumber].gameObject.SetActive(true);
                        openedCards += 1;
                    }
                    else
                    {
                        while (cards[cardNumber].gameObject.activeSelf)
                        {
                            cardNumber = Random.Range(0, cards.Length);
                        }
                    }
                } else
                {
                    while (cards[cardNumber].rarity != 35f)
                    {
                        cardNumber = Random.Range(0, cards.Length);
                    }
                }
            }
            else if (80 < randomValue && randomValue <= 95)
            {
                if (cards[cardNumber].rarity == 15f)
                {
                    if (!cards[cardNumber].gameObject.activeSelf)
                    {
                        cards[cardNumber].gameObject.SetActive(true);
                        openedCards += 1;
                    }
                    else
                    {
                        while (cards[cardNumber].gameObject.activeSelf)
                        {
                            cardNumber = Random.Range(0, cards.Length);
                        }
                    }
                } else
                {
                    while (cards[cardNumber].rarity != 35f)
                    {
                        cardNumber = Random.Range(0, cards.Length);
                    }
                }
            }
            else if (95 < randomValue && randomValue <= 100)
            {
                if (cards[cardNumber].rarity == 5f)
                {
                    if (!cards[cardNumber].gameObject.activeSelf)
                    {
                        cards[cardNumber].gameObject.SetActive(true);
                        openedCards += 1;
                    }
                    else
                    {
                        while (cards[cardNumber].gameObject.activeSelf)
                        {
                            cardNumber = Random.Range(0, cards.Length);
                        }
                    }
                } else
                {
                    while (cards[cardNumber].rarity != 35f)
                    {
                        cardNumber = Random.Range(0, cards.Length);
                    }
                }
            }
        }
        if(openedCards == 3 && isSlot3Full)
        {
            isSinnerChoosing = false;
            openedCards = 0;
            isSlot1Full = false; isSlot2Full = false; isSlot3Full = false;
        }
    }

    public void DestroyCards()
    {
        isPlayed = true;
        cardPanel.SetActive(false);
        gameManager.gameObject.GetComponent<Movement>().canMove = true;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
    }
}
