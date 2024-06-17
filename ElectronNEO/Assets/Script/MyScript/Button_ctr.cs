using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//継承用スクリプト
public class Button_ctr : MonoBehaviour
{
    //シーン遷移にかける時間
    [HideInInspector] public float load_time = 0.5f;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// ボタンを押したらセレクトシーンに移動
    /// </summary>
    public void Go_select()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadSelect", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }

    /// <summary>
    /// ボタンを押したらタイトルシーンに移動
    /// </summary>
    public void Go_Title()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadTitle", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene_E");
    }

    /// <summary>
    /// ボタンを押したらゲームに戻る
    /// </summary>
    public void Back()
    {
        GetComponent<GameManager>().menu.SetActive(false);
        GetComponent<GameManager>().player.GetComponent<Player_ctr>().enabled = true;
        Time.timeScale = 1.0f;
        ButtonSE_ctr.buttonSE = false;
    }

    //-----------------------GameScene---------------------------//

    /// <summary>
    /// ボタンを押したらステージ1-1に移動
    /// </summary>
    public void Game1()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame1", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame1()
    {
        SceneManager.LoadScene("Stage1");
    }

    /// <summary>
    /// ボタンを押したらステージ1-2に移動
    /// </summary>
    public void Game2()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame2", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame2()
    {
        SceneManager.LoadScene("Stage2");
    }

    /// <summary>
    /// ボタンを押したらステージ1-3に移動
    /// </summary>
    public void Game3()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame3", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame3()
    {
        SceneManager.LoadScene("Stage3");
    }

    /// <summary>
    /// ボタンを押したらステージ1-4に移動
    /// </summary>
    public void Game4()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame4", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame4()
    {
        SceneManager.LoadScene("Stage4");
    }

    /// <summary>
    /// ボタンを押したらステージ2-1に移動
    /// </summary>
    public void Game2_1()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame2_1", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame2_1()
    {
        SceneManager.LoadScene("Stage2-1");
    }

    /// <summary>
    /// ボタンを押したらステージ2-2に移動
    /// </summary>
    public void Game2_2()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame2_2", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame2_2()
    {
        SceneManager.LoadScene("Stage2-2");
    }

    /// <summary>
    /// ボタンを押したらステージ2-3に移動
    /// </summary>
    public void Game2_3()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame2_3", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame2_3()
    {
        SceneManager.LoadScene("Stage2-3");
    }

    /// <summary>
    /// ボタンを押したらステージ2-4に移動
    /// </summary>
    public void Game2_4()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame2_4", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame2_4()
    {
        SceneManager.LoadScene("Stage2-4");
    }

    /// <summary>
    /// ボタンを押したらステージ99に移動
    /// </summary>
    public void Game99()
    {
        Noise_ctr.noise_check = true;
        Noise_ctr.noise_in = true;
        Invoke("LoadGame99", load_time);
        Time.timeScale = 1.0f;
    }
    void LoadGame99()
    {
        SceneManager.LoadScene("stage99");
    }
    //--------------------------------------------------------------//
}
