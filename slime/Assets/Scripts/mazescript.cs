using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazescript : MonoBehaviour
{
    [SerializeField]
    Texture2D image;

    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject unacc;


    [SerializeField]
    GameObject groundgroup;
    [SerializeField]
    GameObject wallgroup;

    public int cameraMaxX;
    public int cameraMaxY;
    

    void Start()
    {
        cameraMaxX = image.width;
        cameraMaxY = image.height;

        Pixelreader();
    }
    private void Pixelreader()
    {
        // Load image            
        
        Debug.Log(image);

        // Iterate through it's pixels
        for (int i = 0; i < image.width; i++)
        {
            for (int j = 0; j < image.height; j++)
            {
                Color pixel = image.GetPixel(i, j);



                //// if it's a white color then just debug...
                if (pixel.a == 0)                {
                    Debug.Log("Im grey");
                    GameObject unaccpart = Instantiate(unacc, new Vector3(i, j, 0), Quaternion.Euler(0, 0, 0));
                    unaccpart.transform.parent = this.gameObject.transform;
                }
                
                else if (pixel == Color.black)
                {
                    Debug.Log("Im black");
                    GameObject wallbuild = Instantiate(wall, new Vector3(i, j, 0), Quaternion.Euler(0, 0, 0));
                    wallbuild.transform.parent = wallgroup.transform;
                }
                //else if (pixel.r >= 0.5f)
                //{
                //    Debug.Log("Im red");
                //    GameObject slimestart = Instantiate(ground, new Vector3(i, j, 0), Quaternion.Euler(0, 0, 0));
                //    slimestart.transform.GetComponent<slimeblock>().m_status = 1;
                //}
                //else if (pixel.b >= 0.5f)
                //{
                //    Debug.Log("Im blue");
                //    GameObject finalfood = Instantiate(ground, new Vector3(i, j, 0), Quaternion.Euler(0, 0, 0));
                //    finalfood.transform.GetComponent<slimeblock>().isFinalFood = true;
                //}
                else if (pixel == Color.white)
                {
                    Debug.Log("Im white");
                    GameObject groundbuild = Instantiate(ground, new Vector3(i, j, 0), Quaternion.Euler(0, 0, 0));
                    groundbuild.transform.parent = groundgroup.transform;
                }
            }
        }

        Camera.main.GetComponent<cameramove>().cameralimits();
    }
}
