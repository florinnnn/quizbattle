using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static TextMeshProUGUI countText; // Reference to the TextMeshPro text component
    public static int count = 0;

    void Start()
    {
        countText = GameObject.Find("Text GameScore").GetComponent<TextMeshProUGUI>();

        // Set the initial text to "Score: 0"
        countText.text = "Score: " + count.ToString();
    }

    // Function to increment the count by 1
    public static void IncrementCount()
    {
        count++;
        countText.text = "Score: " + count.ToString();

        // Check if count reaches 100
        if (count >= 100)
        {
            Debug.Log("Congratulations! Count reached 100.");
        }
    }


}
