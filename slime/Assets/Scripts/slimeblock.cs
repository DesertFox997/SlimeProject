using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeblock : MonoBehaviour
{
    
    [SerializeField]
    private float m_lifePoints; 
    [SerializeField]
    public float m_slimeSpreadTime; 
  
    [SerializeField]
    public int m_status=0;

    [SerializeField]
    public bool isFinalFood = false;

    [SerializeField]
    public bool isSlimeStart = false;


    [SerializeField]
    public bool isfood=false;

    [SerializeField]
    public bool isColdEnviroment = false;

    [SerializeField]
    public bool isHotEnviroment = false;

    [SerializeField]
    public bool isInfection = false;

    [SerializeField]
    public bool isfoodadd = false;
    [SerializeField]
    public int isfoodaddamount;

    public GameObject controller;
    RaycastHit2D[] m_nearvyGround;

    bool flagAddInList=false;
    [SerializeField]
    Sprite ground;
    [SerializeField]
    Sprite food;
    [SerializeField]
    Sprite cold;
    [SerializeField]
    Sprite hot;


    RaycastHit2D[] m_nearbySlime;

    [SerializeField]
    public int slimeneighbor;

    // Start is called before the first frame update
    void Start()
    {

        slimeneighbor = 0;

        m_nearbySlime = Physics2D.CircleCastAll(this.gameObject.transform.position, 0.6f, this.gameObject.transform.forward);
       
        if (isFinalFood == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255f, 0, 1f);

            isSlimeStart = false;

        }
        if (isSlimeStart == true)
        {

            m_status = 1;

        }

        if (isHotEnviroment == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hot;
            isColdEnviroment = false;
        }
        if (isColdEnviroment == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cold; 
        }
        if (isfoodadd == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = food; 
        }

        if (isInfection == true)
        {

            isSlimeStart = false;
            m_status = 1;

        }


                              
        controller = GameObject.FindGameObjectWithTag("controller");       
        //cast to find nearby objects
        m_nearvyGround = Physics2D.CircleCastAll(this.gameObject.transform.position, 0.6f, this.gameObject.transform.forward);
        //instaniate the shader material as new so changes wont effect every object
        // this.gameObject.transform.GetComponent<SpriteRenderer>().sharedMaterial = new Material(this.gameObject.GetComponent<SpriteRenderer>().sharedMaterial);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.6f);
    }

    private void FixedUpdate()

    {

        if(m_status>0 && isInfection==true)
        { 
            if(m_lifePoints>=-10)
            {
               
                if(m_status==1)
                {
                    m_lifePoints -= 5 * Time.deltaTime;
                }
                else if (m_status == 2)
                {
                    m_lifePoints -= 4 * Time.deltaTime;
                }
                else if (m_status == 3)
                {
                    m_lifePoints -= 3 * Time.deltaTime;
                }
                else if (m_status == 4)
                {
                    m_lifePoints -= 2 * Time.deltaTime;
                }
                else if (m_status == 5)
                {
                    m_lifePoints -= 1 * Time.deltaTime;
                }

               

            }
            else if(m_lifePoints<=-10)
            {
                this.gameObject.tag = "isinfected";
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                m_status = 10;
                slimeComplete();
                CancelInvoke();

                if(isSlimeStart==true)
                {

                    Debug.Log("defeat");
                }
            }
           


        }
        else if (m_status == 1 && m_lifePoints > 0)
        {
            if(flagAddInList==false)
            {
                controller.gameObject.GetComponent<slimecontroller>().slimebals.Add(this.gameObject);
                m_slimeSpreadTime = controller.GetComponent<slimecontroller>().slimespeed;
                flagAddInList = true;
            }
           

            if(isHotEnviroment == false)
            {
                if(isColdEnviroment == true)
                {
                    m_lifePoints -= (m_slimeSpreadTime/3) * Time.deltaTime;

                }
                else
                {
                    m_lifePoints -= m_slimeSpreadTime * Time.deltaTime;
                }
               
            }

            if(isfoodadd)
            {
                controller.gameObject.GetComponent<slimecontroller>().foodReserves+= isfoodaddamount ;
                isfoodadd = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = ground;
            }

            
           
        }
        else if (m_status == 1 && m_lifePoints <= 0)
        {

            controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);
            this.gameObject.tag = "canwalk";

            InvokeRepeating("CellChecks", 0f, 1f);


            slimeneighbor = 0;
            for (int i = 0; i < m_nearbySlime.Length; i++)
            {
                if (m_nearbySlime[i].transform.gameObject.tag == "canwalk")
                {
                    slimeneighbor += 1;
                }

            }
            if (isFinalFood == true)
            {
                controller.gameObject.GetComponent<slimecontroller>().finalfoodreached = true;
            }
            else if ((slimeneighbor >= 1 &&isSlimeStart==false) || isSlimeStart == true)
            {
                slimeComplete();

            }


        }
        
    }

    public void CellChecks()
    {
        slimeneighbor = 0;
        for (int i = 0; i < m_nearbySlime.Length; i++)
        {
            if (m_nearbySlime[i].transform.gameObject.tag == "canwalk")
            {
                slimeneighbor += 1;
            }

        }
        if(slimeneighbor <=1 && isSlimeStart == false)
        {
            this.gameObject.tag = "ground";
            m_status = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if ((slimeneighbor > 1 && slimeneighbor <=3)|| isSlimeStart==true)
        {

            //growstrong
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            m_status = 3;
        }
        else if(slimeneighbor >=4 && slimeneighbor <5)
        {

            //growstrong
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            m_status = 4;
        }
        else if(slimeneighbor >=5)
        {

            //growstrong
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            m_status = 5;
        }
    }

    public void slimeStart()
    {
        m_status = 1;
    }

    private void slimeComplete()
    {
        for (int i = 0; i < m_nearvyGround.Length; i++)
        {
            if (m_nearvyGround[i].transform.gameObject.tag == "ground" && m_nearvyGround[i].transform.gameObject.GetComponent<slimeblock>().m_status == 0 && isInfection==false)
            {
                m_nearvyGround[i].transform.GetComponent<slimeblock>().slimeStart();
            }
            else if ((m_nearvyGround[i].transform.gameObject.tag == "ground"|| m_nearvyGround[i].transform.gameObject.tag == "canwalk") && isInfection == true)
            {
                m_nearvyGround[i].transform.GetComponent<slimeblock>().isInfection=true;
                m_nearvyGround[i].transform.GetComponent<slimeblock>().slimeStart();

            }
        }      
    }


    public void phase2()
    {
        Debug.Log("inpahse2");

        this.gameObject.tag = "canwalk";

        this.gameObject.GetComponent<slimeblock>().enabled = false;


    }

}
