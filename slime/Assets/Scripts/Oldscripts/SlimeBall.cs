using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{


    public float movementSpeed = 0.5f;

    public int flag;

     public GameObject controller;

    public GameObject node;



    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("controller");

        controller.gameObject.GetComponent<slimecontroller>().slimebals.Add(this.gameObject);

        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag==0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed,Space.Self)  ;
        }


       
        
        
        RaycastHit hitleft;

        RaycastHit hitright;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitleft, 3f) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitright, 3f))
        {
          //  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
           // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
           // Debug.Log("Did Hit");
        }else
        {
         //   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
          //  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
           // Debug.Log("Did not Hit");
            //create node 
            //node spawn stuff       

            GameObject node1 = Instantiate(node, this.gameObject.transform.GetChild(0).gameObject.transform.position, this.gameObject.transform.rotation);
                     
            controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);
            Destroy(this.gameObject);

        }




    }



    public void phaseTwo()
    {


        this.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;

        this.gameObject.transform.GetComponent<Renderer>().enabled = false;

        controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);



    }

    public void OnTriggerEnter(Collider other)
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
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="wall")
        {

            flag = 1;

            this.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;

            this.gameObject.transform.GetComponent<Renderer>().enabled = false;

            controller.gameObject.GetComponent<slimecontroller>().slimebals.Remove(this.gameObject);


        }


    }

}

