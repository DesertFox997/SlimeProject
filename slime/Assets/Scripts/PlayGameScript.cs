using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGameScript : MonoBehaviour
{
    [SerializeField]
    GameObject foodreserves;

    [SerializeField]
    GameObject wallnumbers;


    public void playGame(int scenno)
    {
        

        

        PlayerPrefs.SetInt("food",int.Parse(foodreserves.transform.GetComponent<InputField>().text));
        PlayerPrefs.SetInt("walls", int.Parse(wallnumbers.transform.GetComponent<InputField>().text));

        Debug.Log(PlayerPrefs.GetInt("walls"));
        Debug.Log(PlayerPrefs.GetInt("food"));

        SceneManager.LoadScene(scenno);
    }
}
