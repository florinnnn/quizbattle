using System;
using UnityEngine;

public class PlayHandOccupied : MonoBehaviour
{
    public bool isOccupied = false;
    public event Action<GameObject> OnCardAdded;
    public event Action<GameObject> OnCardRemoved;

    private void Update()
    {
        bool wasOccupied = isOccupied;
        isOccupied = this.transform.childCount > 0;

        if (!wasOccupied && isOccupied)
        {
            GameObject addedCard = transform.GetChild(0).gameObject;
            OnCardAdded?.Invoke(addedCard);
        }
        else if (wasOccupied && !isOccupied)
        {
            GameObject removedCard = wasOccupied ? transform.GetChild(0).gameObject : null;
            OnCardRemoved?.Invoke(removedCard);
        }
    }
}
