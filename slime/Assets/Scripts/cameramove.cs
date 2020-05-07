using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    [SerializeField]
    int speed;

    [SerializeField]
    int maxX;
    [SerializeField]
    int maxY;
    [SerializeField]
    int minX=0;
    [SerializeField]
    int minY=0;

    public void Start()
    {
      
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x <= maxX)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x >= minX)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S) && this.gameObject.transform.position.y >= minY)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W) && this.gameObject.transform.position.y <= maxY)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    public void cameralimits()
    {
        maxX = GameObject.FindGameObjectWithTag("mazegen").GetComponent<mazescript>().cameraMaxX;
        maxY = GameObject.FindGameObjectWithTag("mazegen").GetComponent<mazescript>().cameraMaxY;


    }
}
