using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ReaderExcel : MonoBehaviour
{
    public TextAsset excel;
    private Quiz quiz;
    //public List<QuestionSO> arrayExcel = new List<QuestionSO>();
    // Start is called before the first frame update
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
    }

    void Start()
    {
        readingExcel(quiz.questions);
    }

    public void readingExcel(List<QuestionSO> arrayExcel)
    {
        string[] data = excel.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        for (int i = 0; i < 45; i++)
        {
            arrayExcel[i].setQuestion(data[6 * (i + 1)]);
            // Debug.Log(data[3 * (i + 1)]);
            arrayExcel[i].setAnswer(data[6 * (i + 1) + 1], data[6 * (i + 1) + 2], data[6 * (i + 1) + 3], data[6 * (i + 1) + 4]);
            arrayExcel[i].setIndex(int.Parse(data[6 * (i + 1) + 5]));
        }
    }

}
