using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore_ctr : MonoBehaviour
{
    public static bool on_the_light;

    //Hue値を変化させる変数
    float hue;

    // Start is called before the first frame update
    void Start()
    {
        on_the_light = true;
    }

    // Update is called once per frame
    void Update()
    {
        hue += 0.5f * Time.deltaTime;
        if (hue >= 1.0f)
        {
            hue = 0.0f;
        }
        gameObject.GetComponent<SpriteRenderer>().material.color = UnityEngine.Color.HSVToRGB(hue, 1.0f, 1.0f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "light")
        {
            on_the_light = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "light")
        {
            on_the_light = false;
        }
    }
}
