using UnityEngine;
using UnityEngine.UI;

public class BoardSlotView : MonoBehaviour
{
    public Season season;
    public int slotIndex;

    [SerializeField] private Image cardImage;
    [SerializeField] private Image seedBackImage;
    [SerializeField] private Image ownerTokenIcon;

    public void Render(BoardSlot slot)
    {
        if (slot.isEmpty)
        {
            cardImage.gameObject.SetActive(false);
            seedBackImage.gameObject.SetActive(false);
            ownerTokenIcon.gameObject.SetActive(false);
            return;
        }

        var card = slot.card;
        cardImage.gameObject.SetActive(true);

        if (card.isFaceDown)
        {
            seedBackImage.gameObject.SetActive(true);
            cardImage.gameObject.SetActive(false);
        }
        else
        {
            seedBackImage.gameObject.SetActive(false);
            cardImage.gameObject.SetActive(true);
            cardImage.sprite = card.data.artwork;
        }
    }

}
