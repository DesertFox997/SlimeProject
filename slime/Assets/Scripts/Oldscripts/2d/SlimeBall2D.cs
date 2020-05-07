using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall2D : MonoBehaviour
{


    public float movementSpeed = 0.5f;

    public int flag;

    public GameObject controller;

    public GameObject node;

    public bool readyflag = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");

        controller.gameObject.GetComponent<slimecontroller>().slimebals.Add(this.gameObject);

        flag = 0;

        Invoke("readyflags",1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag==0)
        {
            transform.Translate(Vector2.up * Time.deltaTime * movementSpeed,Space.Self)  ;
        }

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 3f);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f); 

               

        if (((hitleft.collider ==null || hitright.collider ==null) || (hitleft.collider == null && hitright.collider == null)) && readyflag==true)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit");
            //create node
            //node spawn stuff
            GameObject node1 = Instantiate(node, this.gameObject.transform.GetChild(0).gameObject.transform.position, this.gameObject.transform.rotation);
            controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 3f, Color.white);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 3f, Color.white);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * 1f, Color.white);
        }
                     
    }

    public void readyflags()
    {
        readyflag = true;
        Debug.Log(readyflag);
    }

    public void phaseTwo()
    {


        this.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;

        this.gameObject.transform.GetComponent<Renderer>().enabled = false;

        controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       //if(other.tag=="passing")
       // {
            
       //     other.gameObject.transform.GetComponent<passingscript>().m_flagStart = true;
            
       //     flag = 1;

       //     this.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;

       //     //Destroy(this.gameObject);

       //     this.gameObject.transform.GetComponent<Renderer>().enabled = false;

       //     controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);

       // }else 
        if(other.tag == "finalfood")
        {

            controller.gameObject.GetComponent<slimecontroller>().finalfoodreached = true; ;



        }


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {

            flag = 1;

            this.gameObject.transform.GetComponent<Rigidbody2D>().isKinematic = true;

            this.gameObject.transform.GetComponent<Renderer>().enabled = false;

            controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);


        }


    }

}

