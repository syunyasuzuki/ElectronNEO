using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode()]
public class Noise_ctr : MonoBehaviour
{
    [SerializeField]
    Material material;

    string now_scene;

    public static bool noise_check;
    public static bool noise_in;
    public static bool noise_out;

    public static bool death_check;
    public static bool effect_bug;

    bool secret_check;
    bool noise_switch;

    [SerializeField]
    [Range(0, 1)]
    float noiseX;
    public float NoiseX { get { return noiseX; } set { noiseX = value; } }

    [SerializeField]
    [Range(0, 1)]
    float rgbNoise;
    public float RGBNoise { get { return rgbNoise; } set { rgbNoise = value; } }

    [SerializeField]
    [Range(0, 1)]
    float sinNoiseScale;
    public float SinNoiseScale { get { return sinNoiseScale; } set { sinNoiseScale = value; } }

    [SerializeField]
    [Range(0, 10)]
    float sinNoiseWidth;
    public float SinNoiseWidth { get { return sinNoiseWidth; } set { sinNoiseWidth = value; } }

    [SerializeField]
    float sinNoiseOffset;
    public float SinNoiseOffset { get { return sinNoiseOffset; } set { sinNoiseOffset = value; } }

    [SerializeField]
    Vector2 offset;
    public Vector2 Offset { get { return offset; } set { offset = value; } }

    [SerializeField]
    [Range(0, 2)]
    float scanLineTail = 2.0f;
    public float ScanLineTail { get { return scanLineTail; } set { scanLineTail = value; } }

    [SerializeField]
    [Range(-10, 10)]
    float scanLineSpeed = 10;
    public float ScanLineSpeed { get { return scanLineSpeed; } set { scanLineSpeed = value; } }

    // Use this for initialization
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        material.SetFloat("_NoiseX", noiseX);
        material.SetFloat("_RGBNoise", rgbNoise);
        material.SetFloat("_SinNoiseScale", sinNoiseScale);
        material.SetFloat("_SinNoiseWidth", sinNoiseWidth);
        material.SetFloat("_SinNoiseOffset", sinNoiseOffset);
        material.SetFloat("_ScanLineSpeed", scanLineSpeed);
        material.SetFloat("_ScanLineTail", scanLineTail);
        material.SetVector("_Offset", offset);
        Graphics.Blit(src, dest, material);
    }
    // Use this for initialization
    void Start()
    {
        now_scene = SceneManager.GetActiveScene().name;

        noise_check = true;
        noise_out = true;
        noise_in = false;

        if(death_check == false)
        {
            rgbNoise = 1.0f;
            noiseX = 0.0f;
        }
        else if(death_check == true)
        {
            rgbNoise = 0.0f;
            noiseX = 1.0f;
        }

        secret_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(death_check == false)
        {
            if (noise_check == true)
            {
                if (noise_in == true)
                {
                    RGBNoiseIn();
                }
                if (noise_out == true)
                {
                    RGBNoiseOut();
                }
            }
        }

        else if(death_check == true)
        {
            if (noise_check == true)
            {
                if (noise_in == true)
                {
                    NoiseXIn();
                }
                if (noise_out == true)
                {
                    NoiseXOut();
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "SelectScene2")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                secret_check = true;
                noise_switch = true;
            }
        }
        if(secret_check == true)
        {
            SecretNoise();
        }

        if(now_scene == "TitleScene")
        {
            if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.G))
            {
                effect_bug = true;
            }
        }

        if (effect_bug == true)
        {
            if (now_scene == "TitleScene" || now_scene == "SelectScene" || 
                now_scene == "SelectScene2" || now_scene == "SelectScene3"||
                now_scene == "CreditScene")
            {
                sinNoiseScale = 0.0f;
                sinNoiseWidth = 0.0f;
            }
            else
            {
                SinNoise();
            }
        }
        if(effect_bug == false)
        {
            sinNoiseScale = 0.0f;
            sinNoiseWidth = 0.0f;
        }

        if(CreditManager.credit_check == true)
        {
            secret_check = true;
            noise_switch = true;
        }
    }

    /// <summary>
    /// rgbNoiseでフェードイン
    /// </summary>
    void RGBNoiseIn()
    {
        rgbNoise += 2.5f * Time.deltaTime;
        if (rgbNoise >= 1.0f)
        {
            noise_check = false;
            noise_in = false;
        }
    }

    /// <summary>
    /// rgbNoiseでフェードアウト
    /// </summary>
    void RGBNoiseOut()
    {
        rgbNoise -= 2.5f * Time.deltaTime;
        if(rgbNoise <= 0.0f)
        {
            noise_check = false;
            noise_out = false;
        }
    }

    /// <summary>
    /// noiseXでフェードイン
    /// </summary>
    void NoiseXIn()
    {
        noiseX += 2.5f * Time.deltaTime;
        if(noiseX >= 1.0f)
        {
            noise_check = false;
            noise_in = false;
            SceneManager.LoadScene(now_scene);
        }
    }

    /// <summary>
    /// noiseXでフェードアウト
    /// </summary>
    void NoiseXOut()
    {
        noiseX -= 2.5f * Time.deltaTime;
        if (noiseX <= 0.0f)
        {
            noiseX = 0.0f;
            noise_check = false;
            noise_out = false;
        }
    }

    void SinNoise()
    {
        sinNoiseScale = 0.05f;

        if (noise_switch == true)
        {
            sinNoiseWidth += 1.5f * Time.deltaTime;
            if(sinNoiseWidth >= 10.0f)
            {
                noise_switch = false;
            }
        }
        if(noise_switch == false)
        {
            sinNoiseWidth -= 1.5f * Time.deltaTime;
            if(sinNoiseWidth <= 0.0f)
            {
                noise_switch = true;
            }
        }
    }

    /// <summary>
    /// 隠しシーンに移動しようとするときの演出用メソッド
    /// </summary>
    void SecretNoise()
    {
        if(noise_switch == true)
        {
            noiseX += 2.0f * Time.deltaTime;
            if (noiseX >= 0.2f)
            {
                noise_switch = false;
            }
        }
        if(noise_switch == false)
        {
            noiseX -= 2.0f * Time.deltaTime;
            if (noiseX <= 0.0f)
            {
                noiseX = 0.0f;
                secret_check = false;
            }
        }
    }
}
