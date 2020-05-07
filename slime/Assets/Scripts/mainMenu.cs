using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void playGame(int scenno)
    {
        SceneManager.LoadScene(scenno);


    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
