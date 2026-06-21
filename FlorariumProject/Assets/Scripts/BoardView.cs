using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField] private BoardSlotView[] slotViews;

    public void RefreshAll()
    {
        foreach (var view in slotViews)
        {
            var slot = BoardManager.Instance.GetSlot(view.season, view.slotIndex);
            view.Render(slot);
        }
    }
}
