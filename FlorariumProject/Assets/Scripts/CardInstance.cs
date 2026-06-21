using UnityEngine;

[System.Serializable]
public class CardInstance
{
    public CardData data;
    public int ownerId;

    public bool isFaceDown = true;
    public bool isRevealedThisTurn = false;
    public int roundsOnBoard = 0;

    public bool isInmuneThisTurn = false;
    public bool isProtected = false;
    public bool isRemoved = false;

    public int currentValue;

    public CardInstance(CardData data, int ownerId)
    {
        this.data = data;
        this.ownerId = ownerId;
        this.currentValue = data.baseValue;
        this.isFaceDown = true;
    }

    public void Reveal()
    {
        isFaceDown = false;
        isRevealedThisTurn = true;
    }
}
