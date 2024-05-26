using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class On_Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Draggable_Card d = eventData.pointerDrag.GetComponent<Draggable_Card>();
        if (d != null)
        {
            if (this.GetComponent<PlayHandOccupied>() == null || this.GetComponent<PlayHandOccupied>().isOccupied == false)
            {
                d.panel = this.gameObject;
            }
            Debug.Log("onDrop");
        }
        if (eventData.pointerDrag != null)
        {
            Debug.Log(gameObject.name + " Dropped object was: " + eventData.pointerDrag);
        }
    }
}
