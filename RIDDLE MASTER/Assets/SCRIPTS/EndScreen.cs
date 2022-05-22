using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] Text finalText;
    Score score;
    //i find the object using before start   
    void Awake()
    {
        score= FindObjectOfType<Score>();
    }

    public void showFInalScore(){
        finalText.text= "Congratulations! \nYou final score : "+
                         score.calculateScore()+" %";
    }   
}
