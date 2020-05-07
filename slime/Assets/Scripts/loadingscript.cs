using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingscript : MonoBehaviour
{
    [SerializeField]
    Image filler;
    [SerializeField]
    Text hint;
    [SerializeField]
    float loadtime;
    [SerializeField]
    int scenno;
   
    public List<string> hinttexts;

    float nowtime;
    private void Start()
    {
        hinttexts.Add("Most slime moulds live in leaf litter, rotting wood or soil - damp places.");
        hinttexts.Add("Slime sould is a single cell organism");
        hinttexts.Add("Slime moulds can dry out and stay dried for indefinite amounts of time.");


        int randomnum = Random.Range(0, hinttexts.Count);

        hint.text = "hint: " + hinttexts[randomnum];


    }

    // Update is called once per frame
    void Update()
    {
        nowtime += Time.deltaTime;
        filler.fillAmount = nowtime / loadtime;

        if (filler.fillAmount == 1)
        {

            SceneManager.LoadScene(scenno);
        }
    }
}
