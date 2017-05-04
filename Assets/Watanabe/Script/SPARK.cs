using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPARK : MonoBehaviour {
    bool m_xPlus = true;  // x 軸プラス方向に移動中か？

    public GameObject spark;
    bool isspark = false;
    float timer = 0f;
    Vector3 sparkPos;
 
	void Start()
    {

    }


    void Update()
    {
        if(isspark == false)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                sparkPos = transform.position;
                sparkPos.y -= 2;
                Instantiate( spark, sparkPos, Quaternion.identity);
                isspark = true;
            }
        }


        if (m_xPlus)
        {
            transform.position += new Vector3(2f * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= 4)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(2f * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= -4)
                m_xPlus = true;
        }
    }


}

