using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_ctr : MonoBehaviour
{

    [SerializeField] [Header("スイッチプレハブを入れる")] GameObject m_Switch;

    [SerializeField] [Header("光の置く位置の設定")] float light_pos_x;
    [SerializeField] float light_pos_y;

    [SerializeField] [Header("光の大きさを設定")] float light_scale_x = 1.0f;
    [SerializeField] float light_scale_y = 1.0f;

    [SerializeField] [Header("動く光かどうか？")] bool move_check;
    [SerializeField] [Header("TRUE:Y FALSE:X")]bool move_vec;
    [SerializeField] float move_pos;
    [SerializeField] float move_speed;
    float move_pos_x;
    float move_pos_y;
    float stay_time = 1.0f;
    bool move_switch;

    [SerializeField] [Header("点滅する光かどうか？")] bool blinking_check;
    [SerializeField] float blinking_time;

    [SerializeField] [Header("スイッチが必要かどうか？")] bool switch_check;
    [SerializeField] int switch_pos_x;
    [SerializeField] int switch_pos_y;

    // Start is called before the first frame update
    void Start()
    {
        
        if(switch_check == true)
        {
            Instantiate(m_Switch);
        }

        gameObject.transform.position = new Vector3(light_pos_x, light_pos_y);
        gameObject.transform.localScale = new Vector3(light_scale_x, light_scale_y);
        m_Switch.transform.position = new Vector3(switch_pos_x, switch_pos_y);
    }

    // Update is called once per frame
    void Update()
    {
        if(move_check == true)
        {
            Light_Move();
        }

        if(blinking_check == true)
        {
            Light_Blinking();
        }
    }

    void Light_Move()
    {
        // Y軸に移動
        if(move_vec == true)
        {
            if(move_switch == true)
            {
                // move_posが正の値の場合
                if(move_pos >= 0.0f)
                {
                    move_pos_y += move_speed * Time.deltaTime;
                    if (move_pos_y >= move_pos)
                    {
                        move_pos_y = move_pos;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = false;
                        }
                    }
                }
                // move_posが負の値の場合
                if(move_pos < 0.0f)
                {
                    move_pos_y -= move_speed * Time.deltaTime;
                    if (move_pos_y <= move_pos)
                    {
                        move_pos_y = move_pos;
                        stay_time -= 1.0f * Time.deltaTime;
                        if(stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = false;
                        }
                    }
                }
            }
            if(move_switch == false)
            {
                // move_posが正の値の場合
                if(move_pos >= 0.0f)
                {
                    move_pos_y -= move_speed * Time.deltaTime;
                    if (move_pos_y <= 0.0f)
                    {
                        move_pos_y = 0.0f;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = true;
                        }
                    }
                }
                // move_posが負の値の場合
                if(move_pos < 0.0f)
                {
                    move_pos_y += move_speed * Time.deltaTime;
                    if (move_pos_y >= 0.0f)
                    {
                        move_pos_y = 0.0f;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = true;
                        }
                    }
                }
            }
        }
        // X軸に移動
        if(move_vec == false)
        {
            if (move_switch == true)
            {
                // move_posが正の値の場合
                if (move_pos >= 0.0f)
                {
                    move_pos_x += move_speed * Time.deltaTime;
                    if (move_pos_x >= move_pos)
                    {
                        move_pos_x = move_pos;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = false;
                        }
                    }
                }
                // move_posが負の値の場合
                if (move_pos < 0.0f)
                {
                    move_pos_x -= move_speed * Time.deltaTime;
                    if (move_pos_x <= move_pos)
                    {
                        move_pos_x = move_pos;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = false;
                        }
                    }
                }
            }
            if (move_switch == false)
            {
                // move_posが正の値の場合
                if (move_pos >= 0.0f)
                {
                    move_pos_x -= move_speed * Time.deltaTime;
                    if (move_pos_x <= 0.0f)
                    {
                        move_pos_x = 0.0f;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = true;
                        }
                    }
                }
                // move_posが負の値の場合
                if (move_pos < 0.0f)
                {
                    move_pos_x += move_speed * Time.deltaTime;
                    if (move_pos_x >= 0.0f)
                    {
                        move_pos_x = 0.0f;
                        stay_time -= 1.0f * Time.deltaTime;
                        if (stay_time <= 0.0f)
                        {
                            stay_time = 1.0f;
                            move_switch = true;
                        }
                    }
                }
            }
        }
        gameObject.transform.position = new Vector3(light_pos_x + move_pos_x,light_pos_y + move_pos_y, 0.0f);
    }

    void Light_Blinking()
    {

    }
}