using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour, ICustomDrag
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnCurrentDrag()
    {
        rectTransform.position = Input.mousePosition;
    }
}
