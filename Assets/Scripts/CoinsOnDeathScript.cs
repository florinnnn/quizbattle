using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsOnDeathScript : MonoBehaviour
{
    private TextMeshPro fadeAwayText;
    public float fadeDuration = 2f;
    private float fadeSpeed;
    private Color originalColor;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshPro>();
        originalColor = fadeAwayText.color;
        fadeSpeed = originalColor.a / fadeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        originalColor.a -= fadeSpeed * Time.deltaTime;
        if (originalColor.a < 0)
        {
            Destroy(this.gameObject);
        }
        fadeAwayText.color = originalColor;

    }
}
