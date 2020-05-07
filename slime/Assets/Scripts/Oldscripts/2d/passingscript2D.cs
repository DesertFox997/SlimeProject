using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passingscript2D : MonoBehaviour
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

       
       
       
        GameObject newball = Instantiate(slime,this.gameObject.transform.GetChild(0).gameObject.transform.position, this.gameObject.transform.GetChild(0).gameObject.transform.rotation);

        RaycastHit2D hitleft= Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 3f);
        RaycastHit2D hitright= Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 3f);


        if (hitright.collider!=null)
        { GameObject newbal2 = Instantiate(slime, this.gameObject.transform.GetChild(1).gameObject.transform.position, this.gameObject.transform.GetChild(1).gameObject.transform.rotation); }

        if (hitleft.collider != null)
        { GameObject newbal3 = Instantiate(slime, this.gameObject.transform.GetChild(2).gameObject.transform.position, this.gameObject.transform.GetChild(2).gameObject.transform.rotation); }



        //newball.gameObject.transform.GetComponent<SlimeBall>().


    }

  
}
