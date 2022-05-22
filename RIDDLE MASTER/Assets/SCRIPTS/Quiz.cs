using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    //this variable contains the information about the quiz
    private QuestionSO currentQuestion;
    public List<QuestionSO> questions = new List<QuestionSO>();
    [SerializeField] Text textQuestion;

    [Header("Answers")]
    //it's used to allocate the buttons
    [SerializeField] GameObject[] buttonAnswer;
    private int correctAnswerIndex;
    private bool hasAnswerEarly = true;

    [Header("Button Colors")]
    //pi use the sprites to control when the player clicks on
    [SerializeField] Sprite defaultSpriteAnswer;
    [SerializeField] Sprite correctSpriteAnswer;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    private Timer timer;

    [Header("Score")]
    [SerializeField] Text scoreText;
    private Score score;

    [Header("Slider")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    private ReaderExcel reader;

    void Awake()
    {   //displayQuestion();
        //getNextQuestion();
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.maxValue == progressBar.value)
            {
                isComplete = true;
                return;
            }
            hasAnswerEarly = false;
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnswerEarly && !timer.isAnsweringQuestion)
        {
            displayAnswer(-1);
            setButtonState(false);
        }
    }
    //load the answers of the SO and put them the buttons 
    void displayQuestion()
    {
        textQuestion.text = currentQuestion.getQuestion();
        for (int i = 0; i < buttonAnswer.Length; i++)
        {
            //i am using the componets of the children
            Text buttonText = buttonAnswer[i].GetComponentInChildren<Text>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }
    //show answer
    void displayAnswer(int index)
    {
        if (index == currentQuestion.getCorrectAnswerIndex())
        {
            textQuestion.text = "Correcto";
            Image buttonImage = buttonAnswer[index].GetComponent<Image>();
            buttonImage.sprite = correctSpriteAnswer;
            score.incrementCorrectAnswer(13);
        }
        else
        {
            correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            string correctAnswer = currentQuestion.getAnswer(correctAnswerIndex);
            textQuestion.text = "Correct answer is : " + correctAnswer;
            Image buttonImage = buttonAnswer[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctSpriteAnswer;
            score.substractSocre(13);
        }
    }
    //it's used to set the action on the buttons 
    public void answerSelected(int index)
    {
        hasAnswerEarly = true;
        displayAnswer(index);
        setButtonState(false);
        timer.cancelTimer();
        scoreText.text = "Score " + score.calculateScore() + " %";
    }
    //it's used to change th state of the button (interactable)
    void setButtonState(bool state)
    {

        for (int i = 0; i < buttonAnswer.Length; i++)
        {
            //i am using the button components
            Button button = buttonAnswer[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void getNextQuestion()
    {
        if (questions.Count > 0)
        {
            setButtonState(true);
            setDeafaultSprites();
            getRandomQuestion();
            displayQuestion();
            progressBar.value++;
            // score.incrementQuestionSeen();
        }

    }
    //restore the sprites like the beginning
    void setDeafaultSprites()
    {
        for (int i = 0; i < buttonAnswer.Length; i++)
        {
            //i am using the image component
            Image buttonImage = buttonAnswer[i].GetComponent<Image>();
            buttonImage.sprite = defaultSpriteAnswer;
        }
    }

    void getRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }

    }
}



