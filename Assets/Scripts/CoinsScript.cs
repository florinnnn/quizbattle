using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsScript : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Coins: " + GameManagerScript.coins.ToString();
    }
}
