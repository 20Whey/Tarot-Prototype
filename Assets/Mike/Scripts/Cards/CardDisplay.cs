using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
	//all cards
	public Card cardData;

	public TMP_Text nameText;
	public Image cardImage;
	public TMP_Text valueText;


	public void UpdateCard()
	{
		//all cards
		nameText.text = cardData.cardName;
		cardImage.sprite = cardData.cardImage;
		valueText.text = cardData.cardValue.ToString();
	}
}
