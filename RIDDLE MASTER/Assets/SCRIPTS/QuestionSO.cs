using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(menuName = "Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "entre a new question";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    
    public string getQuestion()
    {
        return question;
    }

    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string getAnswer(int index)
    {
        return answers[index];
    }

    //methods set
    public void setQuestion(string question)
    {
        this.question = question;
    }

    public void setIndex(int index)
    {
        this.correctAnswerIndex = index;
    }

    public void setAnswer(string a1,string a2,string a3,string a4)
    {
        answers[0]=a1;
        answers[1]=a2;
        answers[2]=a3;
        answers[3]=a4;
    }


}
