using UnityEngine;

public class CardManager : MonoBehaviour
{
    public bool isSinnerChoosing, isDevilChoosing;

    [Header("UI Part")]
    [SerializeField] GameObject cardPanel;
    [SerializeField] GameObject[] sinnerCards, devilCards;

    [SerializeField] Transform[] cardSlots;
    void Start()
    {
        cardPanel.SetActive(false);
    }

    void Update()
    {
        if(isSinnerChoosing)
        {
            cardPanel.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                int n = Random.Range(0, sinnerCards.Length);
                sinnerCards[n].SetActive(true);
                switch (i)
                {
                    case 0: sinnerCards[n].transform.position = cardSlots[0].position; break;
                    case 1: sinnerCards[n].transform.position = cardSlots[1].position; break;
                    case 2: sinnerCards[n].transform.position = cardSlots[2].position; break;
                }
            }
            isSinnerChoosing = false;
        } else if(isDevilChoosing)
        {
            cardPanel.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                int n = Random.Range(0, devilCards.Length);
                devilCards[n].SetActive(true);
                switch (i)
                {
                    case 0: devilCards[n].transform.position = cardSlots[0].position; break;
                    case 1: devilCards[n].transform.position = cardSlots[1].position; break;
                    case 2: devilCards[n].transform.position = cardSlots[2].position; break;
                }
            }
            isDevilChoosing = false;
        }
    }
}
