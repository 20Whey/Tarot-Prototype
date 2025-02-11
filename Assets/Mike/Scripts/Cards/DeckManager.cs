using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
	public List<Card> allCards = new List<Card>();
	private int currentIndex = 0;

	void Start()
	{
		Card[] cardLibrary = Resources.LoadAll<Card>("Cards");

		allCards.AddRange(cardLibrary);

		HandManager hand = FindFirstObjectByType<HandManager>();
		for (int i = 0; i < 6; i++)
		{
			DrawCard(hand);
		}
	}
	public void DrawCard(HandManager handManager)
	{
		if(allCards.Count == 0)
		{
			return;		
		}

		Card nextCard = allCards[currentIndex];
		handManager.AddCard(nextCard);
		currentIndex = (currentIndex + 1) % allCards.Count;
	}
}
