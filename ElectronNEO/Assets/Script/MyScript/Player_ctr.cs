using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Player_ctr : MonoBehaviour
{

    [SerializeField] GameObject deathEffect;
    [SerializeField] SpriteRenderer core;
    Vector2 SPEED;  // プレイヤーの速度調整

    string now_scene;

    float alpha;
    float r_speed;

    float pos_x;
    float pos_y;

    int count;

    Vector2 pos;
    GameObject Map;
    Camera cam;

    bool move_check;
    public static bool key_get;

    public static bool gameover_check;  //ゲームオーバーになったかどうか判断する変数

    [SerializeField] AudioClip death_se;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        alpha = 0.0f;

        gameover_check = false;

        move_check = true;
        key_get = false;

        now_scene = SceneManager.GetActiveScene().name;

        cam = Camera.main;

        audio = GetComponent<AudioSource>();
        audio.clip = death_se;
    }

    // Update is called once per frame
    void Update()
    {
        if (ClearManager.Clear_check == false)
        {
            r_speed = 3.0f;
        }
        else if (ClearManager.Clear_check == true && gameObject.transform.position.y < 17.0f)
        {
            r_speed = 5.0f;
        }
        else if (ClearManager.Clear_check == true && gameObject.transform.position.y >= 17.0f)
        {
            r_speed = 10.0f;
        }

        if (GameManager.game_start == true)
        {
            alpha += 1.0f * Time.deltaTime;
            if (alpha >= 1.0f)
            {
                move_check = true;
                GameManager.game_start = false;
            }
            else
            {
                move_check = false;
            }

            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        }

        // 光から出たかどうか？
        if (PlayerCore_ctr.on_the_light == false)
        {
            if (alpha >= 1.0f)
            {
                gameover_check = true;
                move_check = false;
            }
        }
        if (gameover_check == true)
        {
            GameOver();
        }

        //move_checkがtrueの時
        if (move_check == true)
        {
            Move();  // 移動処理
        }

        transform.Rotate(new Vector3(0.0f, 0.0f, r_speed));
    }

    /// <summary>
    /// プレイヤーの移動処理を行うメソッド
    /// </summary>
    void Move()
    {
        // 現在位置をpositionに代入
        pos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            r_speed = 6.0f;
            SPEED = new Vector2(0.07f, 0.07f);

            //シフトでダッシュ
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                r_speed = 8.0f;
                SPEED = new Vector2(0.1f, 0.1f);
            }
            // 代入したPositionに対して加算減算を行う
            pos.y += SPEED.y;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            r_speed = 6.0f;
            SPEED = new Vector2(0.07f, 0.07f);

            //シフトでダッシュ
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                r_speed = 8.0f;
                SPEED = new Vector2(0.1f, 0.1f);
            }
            // 代入したPositionに対して加算減算を行う
            pos.y -= SPEED.y;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            r_speed = 6.0f;
            SPEED = new Vector2(0.07f, 0.07f);

            //シフトでダッシュ
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                r_speed = 8.0f;
                SPEED = new Vector2(0.1f, 0.1f);
            }
            // 代入したPositionに対して加算減算を行う
            pos.x -= SPEED.x;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            r_speed = 6.0f;
            SPEED = new Vector2(0.07f, 0.07f);

            //シフトでダッシュ
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                r_speed = 8.0f;
                SPEED = new Vector2(0.1f, 0.1f);
            }
            // 代入したPositionに対して加算減算を行う
            pos.x += SPEED.x;
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = pos;
    }

    /// <summary>
    /// ゲームオーバーになったら呼び出すメソッド
    /// </summary>
    void GameOver()
    {
        alpha -= 2.0f * Time.deltaTime;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            if (core.enabled == true)
            {
                audio.Play();
                GameObject de = Instantiate(deathEffect);
                de.transform.position = transform.position;
            }
            core.enabled = false;
            Noise_ctr.death_check = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "goal" && key_get == true)
        {
            //Debug.Log("おうち入った");
            move_check = false;
            ClearManager.Clear_check = true;
        }
        if (col.gameObject.tag == ("switch"))
        {
            Debug.Log("スイッチ押した！");
        }
        if (col.gameObject.tag == ("key"))
        {
            key_get = true;
            Destroy(col.gameObject);
        }
    }
}
