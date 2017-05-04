using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    private GameObject Press_Enter; //点滅させたい文字

    private float nextTime;
    public float interval = 0.8f; //点滅周期
  

    // Use this for initialization
    void Start()
    {
        Press_Enter = GameObject.Find("PressEnter");
       

        nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        //一定時間ごとに点滅
        if (Time.time > nextTime)
        {
            float alpha = Press_Enter.GetComponent<CanvasRenderer>().GetAlpha();
            
            if (alpha == 1.0f)
                Press_Enter.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            
            else
                Press_Enter.GetComponent<CanvasRenderer>().SetAlpha(1.0f);

            nextTime += interval;
        }

    }
}
