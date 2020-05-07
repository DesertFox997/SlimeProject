using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiscript : MonoBehaviour
{

    [SerializeField]
    Sprite wall;

    [SerializeField]
    Text buttonText;

    [SerializeField]
    public int amountOfWalls = 3;

    public int amountOfWallsReserve = 0;

    public bool wallPressing = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("walls"));

        amountOfWalls = PlayerPrefs.GetInt("walls");
        amountOfWallsReserve = amountOfWalls;

    
        buttonText.text = amountOfWalls + " /"+amountOfWallsReserve;

        
    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0) && amountOfWalls > 0)
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 5f;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            
            Debug.Log(mousepos);
            RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(mousepos.x, mousepos.y), -Vector2.zero, 100);
            if ( wallPressing==true && hit2D.collider !=null)
            {
                wallPressing = false;
               // Debug.Log(hit2D.transform.tag);
               // Debug.Log("Logged");               
               hit2D.transform.tag = "wall";
               hit2D.transform.GetComponent<SpriteRenderer>().sprite = wall;
               amountOfWalls -= 1;
               buttonText.text = amountOfWalls + " /"+amountOfWallsReserve;
            }                   

           
        }
    }

    public void wallpress()
    {
     if (wallPressing)
        {
            wallPressing = false;
            Debug.Log(wallPressing);
        }
        else
        {
            wallPressing = true;
            Debug.Log(wallPressing);
        }
        


    }
    
}
