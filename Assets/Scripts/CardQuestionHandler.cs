using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

public class CardQuestionHandler : MonoBehaviour
{
    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string answer;
        public List<string> answers;
    }

    public GameObject questionPopUpPrefab;
    public WallHealth wallhealth;
    public TextMeshProUGUI damageText;


    public GameObject hand;
    public GameObject playHand;

    public TextMeshProUGUI questionText;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private List<QuestionData> questionList;
    private QuestionData currentQuestion;
    private CardAbility cardAbility;

    private string cardInitialAbility;
    private int cardInitialValue;

    private void Start()
    {
        LoadQuestionsFromJson();
        DisplayRandomQuestion();
    }

    public void SetCardAbility(string ability, int value)
    {
        cardInitialAbility = ability;
        cardInitialValue = value;
    }

    private void LoadQuestionsFromJson()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "questions.json");
        Debug.Log("Loading JSON from: " + filePath);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            try
            {
                questionList = JsonConvert.DeserializeObject<List<QuestionData>>(jsonData);
                Debug.Log("Questions loaded successfully.");
            }
            catch (JsonException ex)
            {
                Debug.LogError("Error deserializing JSON: " + ex.Message);
            }
        }
        else
        {
            Debug.LogError("Cannot find questions.json file at " + filePath);
        }
    }

    public void DisplayRandomQuestion()
    {
        currentQuestion = GetRandomQuestion();
        if (currentQuestion != null)
        {
            UpdateUIWithQuestion(currentQuestion);
        }
        else
        {
            Debug.LogError("No questions available to display.");
        }
    }

    private QuestionData GetRandomQuestion()
    {
        if (questionList != null && questionList.Count > 0)
        {
            int randomIndex = Random.Range(0, questionList.Count);
            return questionList[randomIndex];
        }
        return null;
    }

    private void UpdateUIWithQuestion(QuestionData questionData)
    {
        if (questionText != null)
        {
            questionText.text = questionData.question;
        }
        else
        {
            Debug.LogError("QuestionText component not assigned.");
        }

        UpdateButtonWithAnswer(button1, questionData.answers[0]);
        UpdateButtonWithAnswer(button2, questionData.answers[1]);
        UpdateButtonWithAnswer(button3, questionData.answers[2]);
        UpdateButtonWithAnswer(button4, questionData.answers[3]);
    }

    private void UpdateButtonWithAnswer(Button button, string answerText)
    {
        if (button != null)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = answerText;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnButtonClick(answerText));
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found in button " + button.name);
            }
        }
        else
        {
            Debug.LogError("Button is not assigned.");
        }
    }

    private void OnButtonClick(string selectedButtonText)
    {
        Dictionary<string, string> buttonLetterMap = new Dictionary<string, string>
        {
            { button1.GetComponentInChildren<TextMeshProUGUI>().text, "A" },
            { button2.GetComponentInChildren<TextMeshProUGUI>().text, "B" },
            { button3.GetComponentInChildren<TextMeshProUGUI>().text, "C" },
            { button4.GetComponentInChildren<TextMeshProUGUI>().text, "D" }
        };

        string correctAnswer = currentQuestion.answer;

        Debug.Log("Correct Answer: " + correctAnswer);


        if (buttonLetterMap.ContainsKey(selectedButtonText) && buttonLetterMap[selectedButtonText] == correctAnswer)
        {
            Debug.Log("Correct Answer!");

            if (cardInitialAbility.Equals("Damage"))
            {
                Debug.Log($"arrow damage before {Arrow.arrowDamage}");
                Arrow.arrowDamage += cardInitialValue;

                Debug.Log($"arrow damage after {Arrow.arrowDamage}");
                damageText.text = "Damage " + Arrow.arrowDamage.ToString("0.00");
            }
            if (cardInitialAbility.Equals("Health"))
            {
                Debug.Log($"Health value before {wallhealth.currentHealth}");
                wallhealth.SetDamage(cardInitialValue);
                Debug.Log($"Health value after {wallhealth.currentHealth}");
            }

            questionPopUpPrefab.SetActive(false);
            DisplayRandomQuestion();
            playHand.SetActive(true);
            hand.SetActive(true);
        }
        else
        {
            Debug.Log("Incorrect Answer!");
            questionPopUpPrefab.SetActive(false);
            DisplayRandomQuestion();
            playHand.SetActive(true);
            hand.SetActive(true);

            if (cardInitialAbility.Equals("Damage"))
            {
                Debug.Log($"arrow damage before {Arrow.arrowDamage}");
                Arrow.arrowDamage -= cardInitialValue;
                if (Arrow.arrowDamage < 5)
                {
                    Arrow.arrowDamage = 5;
                }
                Debug.Log($"arrow damage after {Arrow.arrowDamage}");
                damageText.text = "Damage " + Arrow.arrowDamage.ToString("0.00");
            }
            if (cardInitialAbility.Equals("Health"))
            {
                Debug.Log($"Health value before {wallhealth.currentHealth}");
                wallhealth.SetDamage(-cardInitialValue);
                Debug.Log($"Health value after {wallhealth.currentHealth}");
            }
        }

    }

    public bool CheckAnswer(string selectedAnswer)
    {
        if (currentQuestion != null)
        {
            return selectedAnswer == currentQuestion.answer;
        }
        return false;
    }

    public QuestionData GetCurrentQuestion()
    {
        return currentQuestion;
    }
}
