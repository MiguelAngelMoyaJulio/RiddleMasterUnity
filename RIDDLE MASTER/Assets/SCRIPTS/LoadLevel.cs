using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//1.1.0
public class LoadLevel : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("GAME");
    }

    public void loadMain(){
        SceneManager.LoadScene("MAIN MENU");
    }

    public void loadOption(){
        SceneManager.LoadScene("OPTION");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
