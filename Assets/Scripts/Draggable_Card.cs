using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("HELLOOOO!!?!?");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("hell!!?!?");
        //this.transform.localPosition = new Vector3();
        this.transform.localPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ok");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
