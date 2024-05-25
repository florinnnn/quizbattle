using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static TextMeshProUGUI countText; // Reference to the TextMeshPro text component
    public static TextMeshProUGUI scoreText;
    public static int count = 0;

    void Start()
    {
        countText = GameObject.Find("Text GameScore").GetComponent<TextMeshProUGUI>();
        countText.text = "Score: " + count.ToString();// Set the initial text to "Score: 0"

        scoreText = GameObject.Find("Text Score").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Result: " + count.ToString() + " kills";

    }

    // Function to increment the count by 1
    public static void IncrementCount()
    {
        count++;
        countText.text = "Score: " + count.ToString();
        scoreText.text = "Result: " + count.ToString() + " kills";


        // Check if count reaches 100
        if (count >= 100)
        {
            //pt win
            

        }
    }


}
