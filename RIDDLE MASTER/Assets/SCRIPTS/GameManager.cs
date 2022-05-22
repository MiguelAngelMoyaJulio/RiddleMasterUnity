using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Quiz quiz;
    private EndScreen endScreen;
    //version 1.1.0 - add script LoadScene
    private LoadLevel loadLevel;

    void Awake()
    {
        loadLevel = FindObjectOfType<LoadLevel>();
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        changeScreen();
    }

    private void changeScreen()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.showFInalScore();
        }
    }

    public void reloadScene()
    {
        //version 1.1.0 - add script LoadScene
        loadLevel.loadGame();
        //version 1.0.0 of the course
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void returnMainMenu(){
        SceneManager.LoadScene("MAIN MENU");
    }
}
