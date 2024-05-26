using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Draggable_Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 dragOffset;
    public GameObject canvas;
    public GameObject panel;

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (float)(this.transform.position.z - 0.25));
        this.transform.SetParent(this.canvas.transform);
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (eventData.button != PointerEventData.InputButton.Left) return;
        Vector3 worldpoint;
        if (DragWorldPoint(eventData, out worldpoint))
        {
            dragOffset = GetComponent<RectTransform>().position - worldpoint;
        }
        else
        {
            dragOffset = Vector3.zero;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.25f);

        this.transform.SetParent(this.panel.transform);

        Debug.Log("onEndDrag");
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (eventData.button != PointerEventData.InputButton.Left) return;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        Vector3 worldpoint;
        if (DragWorldPoint(eventData, out worldpoint))
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.position = worldpoint + dragOffset;
        }
    }

   
    private bool DragWorldPoint(PointerEventData eventData, out Vector3 worldPoint)
    {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(
            GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint);
    }

    void Start ()
    {
        this.canvas = GameObject.Find("Canvas");
        this.panel = this.transform.parent.gameObject;
    }
    void Update()
    {
        if (this.panel.name == "PlayHand")
        {
            this.gameObject.GetComponent<Draggable_Card>().enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.25f, this.transform.position.z);
    }
}
