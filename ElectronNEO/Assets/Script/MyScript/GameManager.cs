using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : Button_ctr
{
    string now_scene;

    public GameObject menu;
    public GameObject player;

    [SerializeField] Button List1;
    [SerializeField] Button List2;
    [SerializeField] Button List3;

    public static bool game_start;

    [SerializeField] AudioClip game_BGM;
    [SerializeField] AudioClip game_BGM2;

    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        now_scene = SceneManager.GetActiveScene().name;

        audio = GetComponent<AudioSource>();
        if(now_scene == "stage99")
        {
            audio.clip = game_BGM2;
        }
        else
        {
            audio.clip = game_BGM;
        }

        game_start = true;
        menu.SetActive(false);

        audio.Play();

        if(Noise_ctr.death_check == true)
        {
            audio.volume = 1.0f;
            audio.pitch = 2.8f;
        }
        else
        {
            audio.volume = 0.5f;
            audio.pitch = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonSE_ctr.buttonSE = true;
            Noise_ctr.death_check = false;
            menu.SetActive(true);
            List1.Select();
            Time.timeScale = 0.0f;
            player.GetComponent<Player_ctr>().enabled = false;
        }

        if(now_scene == "stage99")
        {
            if(audio.time >= 3.0f)
            {
                audio.time = 0.5f;
            }
        }

        if (audio.pitch > 1.0f)
        {
            audio.volume -= 1.0f * Time.deltaTime;
            audio.pitch -= 4.0f * Time.deltaTime;

            if(audio.volume <= 0.5f)
            {
                audio.volume = 0.5f;
            }
            if(audio.pitch <= 1.0f)
            {
                audio.pitch = 1.0f;
            }
        }

        if(Player_ctr.gameover_check == true)
        {
            if(audio.pitch >= 0.0f)
            {
                audio.pitch -= 1.5f * Time.deltaTime;
            }
            if (Noise_ctr.noise_in == true)
            {
                audio.volume += 1.0f * Time.deltaTime;
                audio.pitch += 4.0f * Time.deltaTime;
            }
        }
    }
}
