using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardAbility : MonoBehaviour
{
    public TextMeshProUGUI abilityTMP;
    public Button acceptButton;
    public Button declineButton;
    public GameObject cardPrefab; // Reference to the card prefab
    public Transform handTransform; // Reference to the Hand GameObject
    public GameObject questionPopUpPrefab; // Reference to the QuestionPopUp prefab

    public Color damageColor = Color.red; // Color for damage cards
    public Color healthColor = Color.green; // Color for health cards

    private string[] abilities = { "Damage", "Health" };
    public string initialAbility;
    public int initialValue;

    private RawImage cardImage;

    void Start()
    {
        InitializeCardAbility();
        SetButtonsActive(false);

        // Add listener for the decline button
        declineButton.onClick.AddListener(DeclineCard);
        acceptButton.onClick.AddListener(AcceptCard);
    }

    void InitializeCardAbility()
    {
        initialAbility = abilities[Random.Range(0, abilities.Length)];
        initialValue = Random.Range(3, 11);

        // Set ability text and color
        if (initialAbility == "Damage")
        {
            abilityTMP.text = $"Damage";
        }
        else
        {
            abilityTMP.text = $"Health";
        }

        // Get the RawImage component
        cardImage = GetComponent<RawImage>();

        // Set card color based on ability
        if (initialAbility == "Damage")
        {
            cardImage.color = damageColor;
        }
        else if (initialAbility == "Health")
        {
            cardImage.color = healthColor;
        }
    }

    void SetButtonsActive(bool isActive)
    {
        acceptButton.gameObject.SetActive(isActive);
        declineButton.gameObject.SetActive(isActive);
    }

    public void OnCardDraggedToPlayHand()
    {
        UpdatePlayHandAbility();
        SetButtonsActive(true);
    }

    public void OnCardRemovedFromPlayHand()
    {
        SetButtonsActive(false);
    }

    void UpdatePlayHandAbility()
    {
        if (initialAbility == "Damage")
        {
            abilityTMP.text = $"Damage - {initialValue}";
        }
        else
        {
            abilityTMP.text = $"Health - {initialValue}";
        }
    }

    
    void DeclineCard()
    {
        // Instantiate a new card in the Hand GameObject
        Instantiate(cardPrefab, handTransform);

        // Destroy the current card
        Destroy(gameObject);
    }

    void AcceptCard()
    {
        // Instantiate a new card in the Hand GameObject
        Instantiate(cardPrefab, handTransform);


        // Set the Hand and PlayHand game objects invisible
        handTransform.gameObject.SetActive(false);
        GameObject playHand = GameObject.Find("PlayHand"); // Adjust the name if necessary
        if (playHand != null)
        {
            playHand.SetActive(false);
        }
        else
        {
            Debug.LogError("PlayHand GameObject not found.");
        }

        // Instantiate the QuestionPopUp prefab
        questionPopUpPrefab.SetActive(true);

        // Destroy the current card
        Destroy(gameObject);
        // You may need to adjust the position and rotation of the instantiated QuestionPopUp
        // E.g., questionPopUp.transform.position = newPosition;
        // E.g., questionPopUp.transform.rotation = newRotation;
    }

}
