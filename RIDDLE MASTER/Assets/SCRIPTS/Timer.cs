using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeCompleteQuestion = 12f;
    [SerializeField] float timeShowCorrectAnswer = 5f;
    private float timerValue;
    public float fillFraction;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;

    // Update is called once per frame
    void Update()
    {
        updateTimer();
    }

    public void cancelTimer(){
        timerValue=0;
    }

    void updateTimer()
    {
        timerValue = timerValue - Time.deltaTime;
        //i'm answering the question
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeCompleteQuestion;
            }
            else
            {
                //time is over and show the correct answer(time) 
                isAnsweringQuestion = false;
                timerValue = timeShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeShowCorrectAnswer;
            }
            else
            {
                //resets values for next question
                loadNextQuestion = true;
                isAnsweringQuestion = true;
                timerValue = timeCompleteQuestion;
            }
        }
    }
}
