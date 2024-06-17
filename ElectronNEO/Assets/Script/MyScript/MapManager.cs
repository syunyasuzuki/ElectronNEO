using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //ライトマネージャーを入れる変数
    [SerializeField] [Header("ライトプレハブを入れる")]GameObject[] m_Light;

    //鍵を入れる変数
    [SerializeField] [Header("鍵を入れる")]GameObject m_Goal_key;

    [SerializeField] int key_pos_x;
    [SerializeField] int key_pos_y;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(m_Goal_key);
        m_Goal_key.transform.position = new Vector3(key_pos_x, key_pos_y);

        for(int i = 0; i < m_Light.Length; i++)
        {
            Instantiate(m_Light[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
