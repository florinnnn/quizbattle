using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI countText; // Reference to the TextMeshPro text component
    public int count = 0;
    public GameObject EndWin;
    public TextMeshProUGUI texthp;

    // Function to increment the count by 1
    public void IncrementCount()
    {
        count++;
        countText.text = "Score: " + count.ToString();
        Debug.Log(count);
        Debug.Log(EndWin);
        if (count >= 1)
        {
            if (EndWin != null)
            {

                EndWin.SetActive(true);
                GameObject castle = GameObject.Find("Castle");
                texthp.text = castle.GetComponent<WallHealth>().currentHealth.ToString();
            }



        }
    }


}
