using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Effect : MonoBehaviour
{
    float scale;
    float alpha;


	// Use this for initialization
	void Start ()
    {
        scale = 0.0f;
        alpha = 1.0f;
        transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
    }
	
	// Update is called once per frame
	void Update ()
    {
        scale += 2.0f * Time.deltaTime;
        alpha -= 1.6f * Time.deltaTime;
        transform.localScale = new Vector2(scale, scale);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (scale >= 3.0f)
        {
            scale = 0.0f;
            alpha = 1.0f;
            transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
        }
	}
}
