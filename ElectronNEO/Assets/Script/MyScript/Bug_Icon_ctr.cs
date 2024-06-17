using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Icon_ctr : MonoBehaviour
{
    [SerializeField] AudioClip icon_SE;

    bool gradation_switch;

    float blue;
    float alpha;

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = icon_SE;

        alpha = 0.0f;
        blue = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //B+U+Gキーが押されたらicon_SEを鳴らす
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.G))
        {
            audio.Play();
        }

        if (Noise_ctr.effect_bug == true)
        {
            BugIcon();
        }
        else
        {
            alpha = 0.0f;
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, blue, alpha);

    }

    void BugIcon()
    {
        if(alpha <= 1.0f)
        {
            alpha += 2.0f * Time.deltaTime;
        }
        if (gradation_switch == true)
        {
            blue += 1.0f * Time.deltaTime;
            if (blue >= 0.6f)
            {
                gradation_switch = false;
            }
        }
        if (gradation_switch == false)
        {
            blue -= 1.0f * Time.deltaTime;
            if (blue <= 0.0f)
            {
                gradation_switch = true;
            }
        }
    }
}
