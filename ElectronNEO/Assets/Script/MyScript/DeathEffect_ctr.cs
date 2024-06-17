using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect_ctr : MonoBehaviour
{
    float effect_rotate;
    float alpha;
    float scale;

    Animator anima;

	// Use this for initialization
	void Start ()
    {
        anima = GetComponent<Animator>();

        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        transform.localScale = new Vector3(scale, scale);
        scale = 0.0f;
        alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Player_ctr.gameover_check == true)
        {
            //effect_rotate = Mathf.Clamp(effect_rotate + Time.deltaTime * 720, 0, 720);
            //transform.eulerAngles = new Vector3(0.0f, 0.0f, effect_rotate);

            anima.SetTrigger("Start_Trigger");
            scale += 7.0f * Time.deltaTime;

            if (scale >= 0.8f)
            {
                alpha -= 5.0f * Time.deltaTime;
            }

            if(alpha <= -1.5f)
            {
                Noise_ctr.noise_check = true;
                Noise_ctr.noise_in = true;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        transform.localScale = new Vector3(scale, scale);
    }
}
