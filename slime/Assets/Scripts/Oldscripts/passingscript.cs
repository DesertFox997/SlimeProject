using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passingscript : MonoBehaviour
{
    [SerializeField]
    public bool m_flagStart;
    [SerializeField]
    GameObject slime;
    public float rotation= 0;

    public bool flagLeft = false;
    public bool flagRight = false;


    public void Start()
    {

       
        this.gameObject.transform.tag = "Untagged";

       
        GameObject newball = Instantiate(slime,this.gameObject.transform.GetChild(0).gameObject.transform.position, this.gameObject.transform.GetChild(0).gameObject.transform.rotation);

        RaycastHit hitleft;
        RaycastHit hitright;


        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitleft, 3f))
        { GameObject newbal2 = Instantiate(slime, this.gameObject.transform.GetChild(1).gameObject.transform.position, this.gameObject.transform.GetChild(1).gameObject.transform.rotation); }

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitright, 3f))
        { GameObject newbal3 = Instantiate(slime, this.gameObject.transform.GetChild(2).gameObject.transform.position, this.gameObject.transform.GetChild(2).gameObject.transform.rotation); }



        //newball.gameObject.transform.GetComponent<SlimeBall>().


    }

  
}
