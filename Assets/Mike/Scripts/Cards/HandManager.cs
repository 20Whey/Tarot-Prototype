using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public DeckManager deckManager;
    public GameObject cardPF;
    public List<GameObject> handCards = new List<GameObject>();
    public Transform handTransform;
    public float verticalCardSpace = 100f;
    public float horizontalCardSpace = 100f;
    public float handSpread = 10f;

    void Start()
    {
       
    }

	public void AddCard(Card cardData)
	{
        if (handCards.Count < 7)
        {
            GameObject newCard = Instantiate(cardPF, handTransform.position, Quaternion.identity, handTransform);
            handCards.Add(newCard);

            newCard.GetComponent<CardDisplay>().cardData = cardData;
            newCard.GetComponent<CardDisplay>().UpdateCard();
            UpdateHand();
        }
	}

	private void UpdateHand()
	{
        int cardCount = handCards.Count;
        if (cardCount == 1)
		{
            handCards[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            handCards[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }
        for (int i=0; i < cardCount; i++)
		{
            float rotationDegree = (handSpread * (i - (cardCount - 1) / 2f));
            handCards[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationDegree);

            float horizontalCardOffset = (horizontalCardSpace * (i - (cardCount - 1) / 2f));

            float positionNormal = (2f * i / (cardCount - 1) - 1f);
            float verticalCardOffset = verticalCardSpace * (1 - positionNormal * positionNormal);

            handCards[i].transform.localPosition = new Vector3(horizontalCardOffset, verticalCardOffset, 0f);
		}
	}
}
