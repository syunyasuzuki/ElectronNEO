using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLock_UI_ctr : MonoBehaviour
{
    Camera cam;

    Animator anima;

    float alpha;

    float cam_x;
    float cam_y;

    bool key_get;
    bool unlock_in;
    bool unlock_out;

    [SerializeField] AudioClip unlock_se;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        key_get = false;
        unlock_in = false;
        unlock_out = false;

        cam = Camera.main;

        alpha = 0.0f;
        anima = GetComponent<Animator>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        audio = GetComponent<AudioSource>();
        audio.clip = unlock_se;
    }

    // Update is called once per frame
    void Update()
    {
        cam_x = cam.transform.position.x;
        cam_y = cam.transform.position.y;

        gameObject.transform.position = new Vector3(cam_x, cam_y, 0.0f);

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (Player_ctr.key_get == true && unlock_out == false)
        {
            key_get = true;
            unlock_in = true;
        }

        if (key_get == true)
        {
            if (unlock_in == true)
            {
                UnLock_In();
            }
            if (unlock_out == true)
            {
                Invoke("UnLock_Out", 0.7f);
            }
        }
    }

    void UnLock_In()
    {
        if (alpha <= 0.5f)
        {
            alpha += 2.0f * Time.deltaTime;
        }
        if (alpha >= 0.5f)
        {
            audio.Play();
            anima.SetTrigger("UnLock_Trigger");
            unlock_in = false;
            unlock_out = true;
        }
    }
    void UnLock_Out()
    {
        alpha -= 2.0f * Time.deltaTime;
    }
}
