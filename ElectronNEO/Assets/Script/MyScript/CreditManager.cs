using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    [SerializeField] GameObject m_Credit;
    [SerializeField] GameObject m_Thank_you;
    [SerializeField] GameObject m_Black;
    [SerializeField] GameObject m_Secret_Code;

    float credit_pos_y;
    float thank_alpha;
    float black_alpha;
    float secret_alpha;

    public static bool credit_check;

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        credit_pos_y = -12.0f;
        thank_alpha = 0.0f;
        black_alpha = 0.0f;
        secret_alpha = 0.0f;

        audio = GetComponent<AudioSource>();

        m_Credit.transform.position = new Vector3(0.0f, credit_pos_y, 0.0f);
        m_Thank_you.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, thank_alpha);
        m_Black.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, black_alpha);
        m_Secret_Code.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, secret_alpha);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(credit_pos_y <= 19.0f)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                credit_pos_y += 5.0f * Time.deltaTime;
            }
            else
            {
                credit_pos_y += 1.0f * Time.deltaTime;
            }
        }
        if(credit_pos_y > 19.0f)
        {
            if(thank_alpha <= 5.0f)
            {
                thank_alpha += 1.0f * Time.deltaTime;
            }
            if(thank_alpha > 4.8)
            {
                audio.pitch = 3.0f;
                credit_check = true;
            }
            if(thank_alpha > 5.0f)
            {
                audio.volume = 0.0f;
                credit_check = false;
                m_Thank_you.SetActive(false);
                secret_alpha += 3.0f * Time.deltaTime;
                black_alpha += 3.0f * Time.deltaTime;
            }
        }

        if (black_alpha > 15.0f)
        {
            Noise_ctr.noise_check = true;
            Noise_ctr.noise_in = true;
            Invoke("GoTitle", 0.5f);
        }

        m_Credit.transform.position = new Vector3(0.0f, credit_pos_y, 0.0f);
        m_Thank_you.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, thank_alpha);
        m_Black.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, black_alpha);
        m_Secret_Code.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, secret_alpha);
	}

    void GoTitle()
    {
        SceneManager.LoadScene("TitleScene_E");
    }
}
