using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : Button_ctr
{


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        //エンターキーを押したら
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Noise_ctr.noise_check = true;
            Noise_ctr.noise_in = true;
            //Go_Selectメソッドを呼ぶ
            Invoke("Go_Select", load_time);
        }

        //エスケープキーを押したら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //アプリを終了させる
            UnityEngine.Application.Quit();

            Noise_ctr.effect_bug = false;
        }
    }

    /// <summary>
    /// セレクトシーンに移動
    /// </summary>
    void Go_Select()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
