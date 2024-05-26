using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardAbility : MonoBehaviour
{
    public TextMeshProUGUI abilityTMP;
    public Button acceptButton;
    public Button declineButton;
    public GameObject cardPrefab;
    public Transform handTransform;
    public GameObject questionPopUpPrefab;

    public Color damageColor = Color.red;
    public Color healthColor = Color.green;
    private string[] abilities = { "Damage", "Health" };
    public string initialAbility;
    public int initialValue;
    public Texture2D myTexture, myTexture2;

    private RawImage cardImage;

    void Start()
    {
        InitializeCardAbility();
        SetButtonsActive(false);
        declineButton.onClick.AddListener(DeclineCard);
        acceptButton.onClick.AddListener(AcceptCard);
    }

    void InitializeCardAbility()
    {
        initialAbility = abilities[Random.Range(0, abilities.Length)];
        initialValue = Random.Range(3, 11);

        if (initialAbility == "Damage")
        {
            abilityTMP.text = $"";
            initialValue = Random.Range(1, 3);
        }
        else
        {
            abilityTMP.text = $"";
        }

        cardImage = GetComponent<RawImage>();

        if (initialAbility == "Damage")
        {
            //cardImage.color = damageColor;
            cardImage.texture = myTexture;
        }
        else if (initialAbility == "Health")
        {
            //cardImage.color = healthColor;
            cardImage.texture = myTexture2;
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
        GameObject card = Instantiate(cardPrefab, handTransform);
        card.gameObject.GetComponent<Draggable_Card>().enabled = true;
        // Destroy the current card
        Destroy(gameObject);
    }

    void AcceptCard()
    {
        CardQuestionHandler questionHandler = FindObjectOfType<CardQuestionHandler>();
        if (questionHandler != null)
        {
            questionHandler.SetCardAbility(initialAbility, initialValue);
        }

        GameObject card = Instantiate(cardPrefab, handTransform);
        card.gameObject.GetComponent<Draggable_Card>().enabled = true;

        handTransform.gameObject.SetActive(false);
        GameObject playHand = GameObject.Find("PlayHand");
        if (playHand != null)
        {
            playHand.SetActive(false);
        }
        else
        {
            Debug.LogError("PlayHand GameObject not found.");
        }

        questionPopUpPrefab.SetActive(true);

        Destroy(gameObject);
    }
}
