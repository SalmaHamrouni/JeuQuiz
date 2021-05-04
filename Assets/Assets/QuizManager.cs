using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;
    [SerializeField]
    private GameObject continentText;
    [SerializeField]
    private Text continentNameQuestion;
    int totalQuestions = 0;
    public int score;
    int range;
    int questions;
    int maxQuestions;
    Continent selectedContinent;
    GameObject scene;
    private void Start()
    {
        CountrySelection.countrySelectedEvent += countrySelected;
        Quizpanel.SetActive(false);
        scene = GameObject.FindGameObjectWithTag("Sprite");
       
       
    }
    private void OnDisable()
    {
        CountrySelection.countrySelectedEvent -= countrySelected;
    }
    private void countrySelected(string country)
    {
        scene.SetActive(false);
        switch (country)
        {
            case "Africa":
               
                selectedContinent= Continent.Africa;
                continentNameQuestion.text = "Africa";
                break;

            case "Asia":
               
                selectedContinent = Continent.Asia;
                continentNameQuestion.text = "Asia";
                break;

            case "Europe":
               
                selectedContinent = Continent.Europe;
                continentNameQuestion.text = "Europe";

                break;

            case "Australia":
               
               selectedContinent = Continent.Australia;
                continentNameQuestion.text = "Australia";
                break;

            case "North america":
                selectedContinent = Continent.North_america;
                continentNameQuestion.text = "North america";
                break;


            case "South america":
                selectedContinent = Continent.South_america;
                continentNameQuestion.text = "South america";
                break;





        }

        CountrySelection.countrySelectedEvent -= countrySelected;
        beginQuestions();

    }

    void beginQuestions() {
        continentText.SetActive(false);
        Quizpanel.SetActive(true);
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateRange(selectedContinent);
        generateQuestion(selectedContinent);

    }

    private void generateRange(Continent continent)
    {
      
        switch (continent)
        {
            case Continent.Africa:
                range = 0;
                break;

            case Continent.Europe:
                range = 5;
                break;
            case Continent.Asia:
                range = 10;
                break;
            case Continent.Australia:
                range = 15;
                break;
            case Continent.South_america:
                range = 20;
                break;
            case Continent.North_america:
                range = 25;
                break;
        }
        maxQuestions = range + 5;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" +5 /*totalQuestions*/;

    }

    public void Correct()
    {
        // when you are right
        score += 1;
   //     QnA.RemoveAt(currentQuestion);
        generateQuestion(selectedContinent);
    }

    public void wrong()
    {
        //when your answer wrong
    //    QnA.RemoveAt(currentQuestion);
        generateQuestion(selectedContinent);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(Continent continent)
    {
    
        if(range <maxQuestions)
        {
            currentQuestion =/* Random.Range(0, QnA.Count)*/range;
           
               

                QuestionTxt.text = QnA[currentQuestion].Question;
            
            SetAnswers();
            range++;
        }
        else
        {
            Debug.Log("Hors des questions");
            GameOver();
        }
    }
}
