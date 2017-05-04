using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPARK : MonoBehaviour {
    bool m_xPlus = true;  // x 軸プラス方向に移動中か？
 
	void Start()
    {
          }


    void Update()
    {
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

