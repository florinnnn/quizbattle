using System;
using UnityEngine;

public class PlayHandOccupied : MonoBehaviour
{
    public bool isOccupied = false;
    public event Action<GameObject> OnCardAdded;

    private void Start()
    {

    }

    private void Update()
    {
        bool wasOccupied = isOccupied;
        isOccupied = this.transform.childCount > 0;

        if (!wasOccupied && isOccupied)
        {
            GameObject addedCard = transform.GetChild(0).gameObject;
            OnCardAdded?.Invoke(addedCard);
        }
    }
}
