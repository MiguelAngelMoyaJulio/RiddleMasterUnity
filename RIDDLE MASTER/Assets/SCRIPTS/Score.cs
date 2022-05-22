using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{

    private int correctAnswers = 0;
    private int questionSeen = 0;

    public int getCorrectAnswer()
    {
        return correctAnswers;
    }

    public void substractSocre(int looseScore)
    {
        if (this.correctAnswers - looseScore >= 0)
        {
            this.correctAnswers = this.correctAnswers - 13;
        }
        else
        {
            this.correctAnswers = 0;
        }
    }
    // public int getQuestionSeen()
    // {
    //     return questionSeen;
    // }

    public void incrementCorrectAnswer(int winScore)
    {
        //this.correctAnswers++;
        this.correctAnswers = this.correctAnswers + winScore;
    }

    // part of the first version of the course
    // public void incrementQuestionSeen()
    // {
    //     this.questionSeen++;
    // }

    public int calculateScore()
    {
        return this.correctAnswers;
        // return Mathf.RoundToInt(correctAnswers / (float)questionSeen * 100);
    }
}
