using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : Button_ctr
{
    string now_scene;

    int secret_count;

    [SerializeField] AudioClip select_BGM;
    [SerializeField] AudioClip secret_BGM;

    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        now_scene = SceneManager.GetActiveScene().name;

        audio = GetComponent<AudioSource>();
        if (now_scene == "SelectScene3")
        {
            audio.clip = secret_BGM;
        }
        else
        {
            audio.clip = select_BGM;
        }
        audio.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(now_scene == "SelectScene")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Noise_ctr.noise_check = true;
                Noise_ctr.noise_in = true;
                Invoke("LoadSelect2", load_time);
            }
        }

        if(now_scene == "SelectScene2")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Noise_ctr.noise_check = true;
                Noise_ctr.noise_in = true;
                Invoke("LoadSelect1", load_time);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                secret_count += 1;
            }
        }
        if(secret_count == 10)
        {
            Noise_ctr.noise_check = true;
            Noise_ctr.noise_in = true;
            Invoke("LoadSelect3", load_time);
        }

        if(now_scene == "SelectScene3")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Noise_ctr.noise_check = true;
                Noise_ctr.noise_in = true;
                Invoke("LoadSelect2", load_time);
            }
            if (audio.time >= 3.0f)
            {
                audio.time = 0.5f;
            }
        }
	}

    void LoadSelect1()
    {
        SceneManager.LoadScene("SelectScene");
    }

    void LoadSelect2()
    {
        SceneManager.LoadScene("SelectScene2");
    }

    void LoadSelect3()
    {
        SceneManager.LoadScene("SelectScene3");
    }
}
