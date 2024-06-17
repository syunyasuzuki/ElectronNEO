using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_ctr : MonoBehaviour
{
    float alpha;

    Animator anima;

    // Use this for initialization
    void Start ()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "player")
        {
            anima.SetTrigger("ON_Trigger");
        }
        if(col.gameObject.tag == "light")
        {
            alpha = 1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "light")
        {
            alpha = 0.0f;
        }
    }
}
