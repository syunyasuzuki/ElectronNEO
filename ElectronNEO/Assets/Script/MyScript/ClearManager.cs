using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClearManager : Button_ctr
{
    //現在のシーン名を取得する変数
    string now_scene;

    //クリアしたかどうかを判定する変数
    public static bool Clear_check;

    //プレイヤーを取得する変数
    public GameObject player;

    //メインカメラを取得する変数
    Camera cam;

    AudioSource audio;

    //-----------クリアメニュー一覧を取得する変数たち-----------//
    [SerializeField] GameObject panel;
    [SerializeField] Image Clear_Logo;
    [SerializeField] Image clear_Effect;
    [SerializeField] Image Clear_menu;
    [SerializeField] Image Next;
    [SerializeField] Image Select;
    [SerializeField] Image Retry;

    [SerializeField] Button List1;
    [SerializeField] Button List2;
    [SerializeField] Button List3;
    //-------------------------------------------------------//

    //プレイヤーの大きさを変える変数
    float player_scale;
    //プレイヤーの透明度を変える変数
    float player_alpha;

    //プレイヤーの現在地を取得する変数（X軸用）
    float player_now_x;
    //プレイヤーの現在地を取得する変数（Y軸用）
    float player_now_y;

    //クリアメニューの透明度を変える変数
    float alpha;

    //クリアロゴのY軸移動に使う変数
    float Y = 4.0f;

    float effect_scale;

    float effect_alpha;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();

        effect_alpha = 1.0f;
        effect_scale = 0.0f;

        //現在のシーン名取得
        now_scene = SceneManager.GetActiveScene().name;

        //パネルを非表示
        panel.SetActive(false);

        //メインカメラを取得
        cam = Camera.main;

        //クリアチェックの初期化
        Clear_check = false;

        //クリアメニューアルファ値の初期化
        alpha = 0.0f;

        //プレイヤーアルファ値の初期化
        player_alpha = 1.0f;

        //プレイヤースケールの初期化
        player_scale = 1.0f;

        //クリアメニューの初期値設定
        Clear_menu.rectTransform.localPosition = new Vector3(-30.0f, -500.0f, 0.0f);

        //上記値を反映
        Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        clear_Effect.color = new Color(1.0f, 1.0f, 1.0f, effect_alpha);
        clear_Effect.GetComponent<RectTransform>().localScale = new Vector3(effect_scale, effect_scale);
    }

    // Update is called once per frame
    void Update ()
    {
        //クリアしていない場合
        if(Clear_check == false)
        {
            //プレイヤーの現在地を取得し続ける
            player_now_x = player.transform.position.x;
            player_now_y = player.transform.position.y;
        }

        //クリアした場合
        if (Clear_check == true)
        {
            //Noise_ctrスクリプトのdeath_checkをfalseにする
            Noise_ctr.death_check = false;

            //ゲームクリアメソッドを呼ぶ
            GameClear();
        }
    }

    /// <summary>
    /// ステージクリアしたら呼び出すメソッド
    /// </summary>
    void GameClear()
    {
        //プレイヤーの現在地（X）が0.0以下だった場合
        if(player_now_x <= 0.0f)
        {
            player_now_x += 1.0f * Time.deltaTime;
        }
        //プレイヤーの現在地（X）が0.0以上だった場合
        if (player_now_x >= 0.0f)
        {
            player_now_x -= 1.0f * Time.deltaTime;
        }

        if(player_now_x >= -0.03f && player_now_x <= 0.03f)
        {
            if(player_now_y <= 17.0f)
            {
                player_now_y += 1.0f * Time.deltaTime;
            }
        }

        if (player.transform.position.y >= 17.0f)
        {
            player.transform.localScale = new Vector3(player_scale, player_scale);
            player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, player_alpha);
            if(player_scale >= 0.0f)
            {
                player_scale -= 1.0f * Time.deltaTime;
                player_alpha -= 1.0f * Time.deltaTime;
            }
            else
            {
                if(now_scene == "stage99")
                {
                    Noise_ctr.noise_check = true;
                    Noise_ctr.noise_in = true;
                    Invoke("LoadCredit", load_time);
                }
                else
                {
                    panel.SetActive(true);
                    Clear_Effect();
                    Invoke("GameClear2", 1.0f);
                }
            }
        }
        player.transform.position = new Vector3(player_now_x, player_now_y);
    }

    void GameClear2()
    {
        if (Clear_Logo.rectTransform.localPosition.y <= 130)
        {
            Clear_Logo.rectTransform.localPosition += new Vector3(0.0f, Y, 0.0f);
        }
        else
        {
            List1.Select();
            Clear_menu.rectTransform.localPosition = new Vector3(-30.0f, -20.0f, 0.0f);
            alpha += 0.05f;
            Next.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Select.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            Retry.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            if (alpha >= 1.0f)
            {
                ButtonSE_ctr.buttonSE = true;
                Clear_check = false;
            }
        }
    }

    void Clear_Effect()
    {
        if(effect_scale <= 0.0f)
        {
            audio.Play();
        }
        effect_scale += 10.0f * Time.deltaTime;
        effect_alpha -= 2.5f * Time.deltaTime;
        clear_Effect.color = new Color(1.0f, 1.0f, 1.0f, effect_alpha);
        clear_Effect.GetComponent<RectTransform>().localScale = new Vector3(effect_scale, effect_scale);    
    }

    void LoadCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
