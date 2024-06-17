using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Electron_Back_ctr : MonoBehaviour
{
    string now_scene;

	// Use this for initialization
	void Start ()
    {
        now_scene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (now_scene == "TitleScene")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.5f, 1.0f);
        }
        else if (now_scene == "SelectScene")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.5f, 1.0f);
        }
        else if(now_scene == "SelectScene2")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.5f, 0.0f);
        }
        else if(now_scene == "SelectScene3")
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.0f, 0.0f);
        }
	}
}
