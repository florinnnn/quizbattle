using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static TextMeshProUGUI countText; // Reference to the TextMeshPro text component
    public static int count = 0;
    public GameObject EndWin;
    //public static TextMeshProUGUI texthp;

    void Start()
    {
       
       // texthp = GameObject.Find("Text HPLeft").GetComponent<TextMeshProUGUI>();
        countText = GameObject.Find("Text GameScore").GetComponent<TextMeshProUGUI>();
        countText.text = "Score: " + count.ToString();// Set the initial text to "Score: 0"

    }

    // Function to increment the count by 1
    public static void IncrementCount()
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
                //GameObject castle = GameObject.Find("Castle");
                //texthp.text = castle.GetComponent<WallHealth>().currentHealth.ToString();
            }



        }
    }


}
