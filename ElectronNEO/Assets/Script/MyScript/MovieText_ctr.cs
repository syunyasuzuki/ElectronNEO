using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieText_ctr : MonoBehaviour
{

    [SerializeField] Image m_TextBack;

    [SerializeField] Image m_First_text;
    [SerializeField] Image m_Second_text;
    [SerializeField] Image m_Third_text;
    [SerializeField] Image m_Fourth_text;
    [SerializeField] Image m_Fifth_text;
    [SerializeField] Image m_Sixth_text;
    [SerializeField] Image m_Seventh_text;

    bool text_back_check;

    bool first_text_check;
    bool second_text_check;
    bool third_text_check;
    bool fourth_text_check;
    bool fifth_text_check;
    bool sixth_text_check;
    bool seventh_text_check;

    float back_alpha;
    float text_alpha;

    float scale_X;
    float scale_Y;

	// Use this for initialization
	void Start ()
    {
        scale_X = 10.0f;
        scale_Y = 10.0f;
        back_alpha = 0.0f;
        text_alpha = 0.0f;

        text_back_check = false;

        first_text_check = false;
        second_text_check = false;
        third_text_check = false;
        fourth_text_check = false;
        fifth_text_check = false;
        sixth_text_check = false;
        seventh_text_check = false;

        m_TextBack.color = new Color(1.0f, 1.0f, 1.0f, back_alpha);
        m_First_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
        m_TextBack.rectTransform.sizeDelta = new Vector2(scale_X, scale_Y);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) ||
            Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) ||
            Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Alpha6) ||
            Input.GetKey(KeyCode.Alpha7))
        {
            text_back_check = true;
        }
        else
        {
            text_back_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            first_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            first_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            second_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            second_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            third_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            third_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            fourth_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            fourth_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            fifth_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            fifth_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            sixth_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            sixth_text_check = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            seventh_text_check = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            seventh_text_check = false;
        }


        if(text_back_check == true)
        {
            TextBackOpen();
        }
        if(text_back_check == false)
        {
            TextBackClose();
        }

        if (first_text_check == true)
        {
            FirstTextOpen();
        }
        if(first_text_check == false)
        {
            FirstTextClose();
        }

        if(second_text_check == true)
        {
            SecondTextOpen();
        }
        if(second_text_check == false)
        {
            SecondTextClose();
        }

        if(third_text_check == true)
        {
            ThirdTextOpen();
        }
        if(third_text_check == false)
        {
            ThirdTextClose();
        }

        if(fourth_text_check == true)
        {
            FourthTextOpen();
        }
        if(fourth_text_check == false)
        {
            FourthTextClose();
        }

        if(fifth_text_check == true)
        {
            FifthTextOpen();
        }
        if(fifth_text_check == false)
        {
            FifthTextClose();
        }

        if(sixth_text_check == true)
        {
            SixthTextOpen();
        }
        if(sixth_text_check == false)
        {
            SixthTextClose();
        }

        if(seventh_text_check == true)
        {
            SeventhTextOpen();
        }
        if(seventh_text_check == false)
        {
            SeventhTextClose();
        }

        m_TextBack.color = new Color(1.0f, 1.0f, 1.0f, back_alpha);
        m_TextBack.rectTransform.sizeDelta = new Vector2(scale_X, scale_Y);
    }

    void TextBackOpen()
    {
        back_alpha = 1.0f;
        if(scale_Y <= 80)
        {
            scale_Y += 1500.0f * Time.deltaTime;
        }
        if(scale_Y > 80)
        {
            scale_Y = 80;
            if (scale_X <= 800)
            {
                scale_X += 3000.0f * Time.deltaTime;
                if(scale_X > 800)
                {
                    scale_X = 800;
                }
            }
        }
    }

    void TextBackClose()
    {
        text_alpha = 0.0f;
        if(scale_X >= 10.0f)
        {
            scale_X -= 3000.0f * Time.deltaTime;
        }
        if(scale_X < 10.0f)
        {
            scale_X = 10.0f;
            if(scale_Y >= 10.0f)
            {
                scale_Y -= 1500.0f * Time.deltaTime;
            }
            if(scale_Y < 10.0f)
            {
                scale_Y = 10.0f;
                back_alpha = 0.0f;
            }
        }
    }
    
    void FirstTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_First_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void FirstTextClose()
    {
        text_alpha = 0.0f;
        m_First_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void SecondTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Second_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void SecondTextClose()
    {
        text_alpha = 0.0f;
        m_Second_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void ThirdTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Third_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void ThirdTextClose()
    {
        text_alpha = 0.0f;
        m_Third_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void FourthTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Fourth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void FourthTextClose()
    {
        text_alpha = 0.0f;
        m_Fourth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void FifthTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Fifth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void FifthTextClose()
    {
        text_alpha = 0.0f;
        m_Fifth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void SixthTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Sixth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void SixthTextClose()
    {
        text_alpha = 0.0f;
        m_Sixth_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }

    void SeventhTextOpen()
    {
        if(scale_X >= 800.0f)
        {
            text_alpha = 1.0f;
        }
        m_Seventh_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
    void SeventhTextClose()
    {
        text_alpha = 0.0f;
        m_Seventh_text.color = new Color(1.0f, 1.0f, 1.0f, text_alpha);
    }
}
