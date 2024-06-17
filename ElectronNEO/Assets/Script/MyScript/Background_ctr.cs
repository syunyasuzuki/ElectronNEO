using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background_ctr : MonoBehaviour
{
    //今のシーン名を取得する変数
    string now_scene;

    //Hue値を変化させる変数
    float hue;

    float color_switch;

    float red;
    float green;
    float blue;

	// Use this for initialization
	void Start ()
    {
        //今のシーン名を取得
        now_scene = SceneManager.GetActiveScene().name;

        //ステージ1-1、1-2、1-3、1-4だった時
        if(now_scene == "Stage1-1" || now_scene == "Stage1-2" || now_scene == "Stage1-3" || now_scene == "Stage1-4")
        {
            //背景色を青
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.5f, 1.0f);
        }
        //ステージ2-1、2-2、2-3、2-4だった時
        if(now_scene == "Stage2-1" || now_scene == "Stage2-2" || now_scene == "Stage2-3" || now_scene == "Stage2-4")
        {
            //背景色を緑
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f);
        }
        //ステージ99だった時
        if(now_scene == "stage99")
        {
            //背景色を赤
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
        }

        red = 1.0f;
        green = 1.0f;
        blue = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //クレジットシーンだった場合
		if(now_scene == "CreditScene")
        {
            //背景色を虹色に変化させる
            //hue += 0.5f * Time.deltaTime;
            //if (hue >= 1.0f)
            //{
            //    hue = 0.0f;
            //}
            //gameObject.GetComponent<SpriteRenderer>().material.color = UnityEngine.Color.HSVToRGB(hue, 1.0f, 1.0f);

            color_switch += 0.958f * Time.deltaTime;
            if(color_switch >= 1.0f && color_switch < 2.0f)
            {
                red = 1.0f;
                green = 0.0f;
                blue = 0.0f;
            }
            if(color_switch >= 2.0f && color_switch < 3.0f)
            {
                red = 0.0f;
                green = 1.0f;
                blue = 0.0f;
            }
            if(color_switch >= 3.0 && color_switch < 4.0f)
            {
                red = 0.0f;
                green = 0.5f;
                blue = 1.0f;
                color_switch = 0.0f;
            }
            gameObject.GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
        }
	}
}
