using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSE_ctr : MonoBehaviour
{
    AudioSource audio;
    string now_scene;

    public static bool buttonSE;

	// Use this for initialization
	void Start ()
    {
        buttonSE = false;
        now_scene = SceneManager.GetActiveScene().name;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(now_scene == "SelectScene" || now_scene == "SelectScene2" || now_scene == "SelectScene3" || now_scene == "TitleScene_E")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                audio.Play();
            }
        }
        else
        {
            if(buttonSE == true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    audio.Play();
                }
            }
        }
    }
}
