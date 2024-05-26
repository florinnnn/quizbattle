using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public int count = 0;
    public GameObject EndWin;
    public TextMeshProUGUI texthp;

    public void IncrementCount()
    {
        count++;
        countText.text = "Score: " + count.ToString();
        Debug.Log(count);
        Debug.Log(EndWin);
        if (count >= 100)
        {
            if (EndWin != null)
            {

                EndWin.SetActive(true);
                GameObject castle = GameObject.Find("Castle");
                texthp.text = "Remaining hp: " + castle.GetComponent<WallHealth>().currentHealth.ToString();
            }



        }
    }


}