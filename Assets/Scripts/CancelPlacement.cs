using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPlacement : MonoBehaviour
{
    public void SetDraggingFalse()
    {
        Debug.Log("SetDraggingFalse");
        DraggableTurret.dragging = false;
    }
}
