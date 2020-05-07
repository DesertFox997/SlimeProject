using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimecontroller : MonoBehaviour
{


    [SerializeField]
    public float foodReserves=0;


    [SerializeField]
    public bool finalfoodreached;
    
    public List<GameObject> slimebals;

    [SerializeField]
    public float slimespeed;

    [SerializeField]
    Text food;

    [SerializeField]
    Slider slimespeedslider;

    [SerializeField]
    GameObject phasseText;

    float slimespeedold;

    [SerializeField]
    GameObject gameOverMenu;

    [SerializeField]
    int noOfWalls;

    
    // Start is called before the first frame update
    void Start()
    {
       
        foodReserves = PlayerPrefs.GetInt("food");
         
        slimespeedold = slimespeed;
        finalfoodreached = false;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (foodReserves>0)
        {
            foodReserves -= Time.deltaTime * slimebals.Count * slimespeed;
        }
        else
        {
            gameOverMenu.SetActive(true);
        }       
        //  Debug.Log(foodReserves);           
        slimespeed = slimespeedslider.value;
        if (finalfoodreached == false )
        {
            if (slimespeed != slimespeedold && slimebals.Count != 0)
            {
                slimespeedold = slimespeed;
                for (int i = 0; i < slimebals.Count; i++)
                {
                    slimebals[i].gameObject.GetComponent<slimeblock>().m_slimeSpreadTime = slimespeed;
                }
            }
            food.text = foodReserves.ToString();
        }
        else if (finalfoodreached == true)
        {
            for (int i =0;i<slimebals.Count; i++)
            {
                slimebals[i].gameObject.GetComponent<slimeblock>().phase2();

                phasseText.transform.gameObject.SetActive(true);
            }
        }       
    }


}
