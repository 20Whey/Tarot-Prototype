using UnityEngine;

[CreateAssetMenu(fileName = "Create Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardValue;
    public CardType cardType;
    public bool straightUp = true;
    public Sprite cardImage;

    public enum CardType
    {
        Chalice,
        Pentacles,
        Swords,
        Wands,
        Arcana
    }
}
