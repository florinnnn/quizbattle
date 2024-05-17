using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CardQuestionHandler : MonoBehaviour
{
    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string answer;
        public List<string> answers;
    }

    public GameObject playHand;
    private List<QuestionData> questionList;

    private void Start()
    {
        LoadQuestionsFromJson();
        PlayHandOccupied playHandOccupied = playHand.GetComponent<PlayHandOccupied>();
        if (playHandOccupied != null)
        {
            playHandOccupied.OnCardAdded += OnCardMoved;
        }
        else
        {
            Debug.LogError("PlayHandOccupied component not found on playHand GameObject.");
        }
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

    public void OnCardMoved(GameObject card)
    {
        QuestionData questionData = GetRandomQuestion();
        if (questionData != null)
        {
            UpdateCardWithQuestion(card, questionData);
        }
        else
        {
            Debug.LogError("No questions available to assign.");
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

    private void UpdateCardWithQuestion(GameObject card, QuestionData questionData)
    {
        Transform questionStructure = card.transform.Find("QuestionStructure");

        if (questionStructure != null)
        {
            TextMeshProUGUI questionText = questionStructure.Find("Question").GetComponent<TextMeshProUGUI>();
            if (questionText != null)
            {
                questionText.text = questionData.question;
            }
            else
            {
                Debug.LogError("QuestionText component not found in QuestionStructure.");
            }

            for (int i = 0; i < 4; i++)
            {
                string buttonName = "Answer" + (i + 1);
                Transform buttonTransform = questionStructure.Find(buttonName);
                if (buttonTransform != null)
                {
                    TextMeshProUGUI answerText = buttonTransform.GetComponentInChildren<TextMeshProUGUI>();
                    if (answerText != null)
                    {
                        answerText.text = questionData.answers[i];
                    }
                    else
                    {
                        Debug.LogError("TextMeshProUGUI component not found in " + buttonName);
                    }
                }
                else
                {
                    Debug.LogError(buttonName + " not found in QuestionStructure.");
                }
            }

            questionStructure.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("QuestionStructure not found in card GameObject.");
        }
    }
}
