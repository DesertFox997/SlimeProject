using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class mazeloader : MonoBehaviour
{





    [SerializeField]
    GameObject missionui;

    // Start is called before the first frame update
    void Start()
    {
        

        string myPath = "Assets/Resources/";

        Texture2D mytexture = null;

        DirectoryInfo dir = new DirectoryInfo(myPath);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info)
        {
            if (f.Extension == ".png")
            {                
                f.IsReadOnly=false;
                GameObject maze = Instantiate(missionui,this.gameObject.transform.position,this.gameObject.transform.rotation);
                byte[] filedata = File.ReadAllBytes("Assets/Resources/"+f.Name);
                mytexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                mytexture.LoadImage(filedata);
                Sprite mysprite = Sprite.Create(mytexture,new Rect(0.0f, 0.0f, mytexture.width, mytexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                maze.transform.GetComponent<Image>().sprite= mysprite;
                maze.name = f.Name;
                maze.transform.parent = this.gameObject.transform;                
            }
        }

    }
}
