using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClearUI : MonoBehaviour, IPointerClickHandler
{
    private bool isShowing = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (isShowing == true)
        {
            canvas.SetActive(isShowing);
            isShowing = true;
        }
        
    }

}
