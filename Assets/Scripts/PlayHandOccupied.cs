using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHandOccupied : MonoBehaviour
{
    public bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount == 0)
        {
            isOccupied = false;
        }
        else
        {
            isOccupied = true;
        }
    }
}
