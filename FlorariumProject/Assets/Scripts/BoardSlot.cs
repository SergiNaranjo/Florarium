using UnityEngine;

[System.Serializable]
public class BoardSlot 
{
    public Season season;
    public int slotIndex;
    public CardInstance card;

    public bool isEmpty => card == null;
}
