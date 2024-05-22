using UnityEngine;

public class PlayHandEventHandler : MonoBehaviour
{
    public PlayHandOccupied playHandOccupied;

    private void Start()
    {
        playHandOccupied.OnCardAdded += HandleCardAdded;
        playHandOccupied.OnCardRemoved += HandleCardRemoved;
    }

    private void HandleCardAdded(GameObject card)
    {
        CardAbility cardAbility = card.GetComponent<CardAbility>();
        if (cardAbility != null)
        {
            cardAbility.OnCardDraggedToPlayHand();
        }
    }

    private void HandleCardRemoved(GameObject card)
    {
        CardAbility cardAbility = card.GetComponent<CardAbility>();
        if (cardAbility != null)
        {
            cardAbility.OnCardRemovedFromPlayHand();
        }
    }
}
