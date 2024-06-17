using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret_SE_ctr : MonoBehaviour
{

    [SerializeField] AudioClip secret_SE;

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = secret_SE;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audio.time = 0.1f;
            audio.Play();
        }
	}
}
