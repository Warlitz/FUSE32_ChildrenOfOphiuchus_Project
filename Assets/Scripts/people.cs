using UnityEngine;
using System.Collections;
using UnityEngine.UI;//uGUIにアクセス
 [RequireComponent(typeof(AudioSource))]

public class people : MonoBehaviour
{
    public float settime;
    public float recovertime;
    public float recoverlength;
    private float time = 0;
    private float time2 = 0;
    private bool Cflag = false;
    private bool Mflag = false;
    private bool setok = false;
    static int recovercount =0;
    private AudioSource m_Audio;
    private Vector3 peoplePosition;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.clear;
        m_Audio = GetComponent<AudioSource>();
        peoplePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (setok == false)
        {
            time += Time.deltaTime;//時間更新(徐々に増やす)
            if (Cflag == false)
            {
                //clear(Color(0,0,0))から white(Color(1,1,1))に時間をかけて変更
                GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.clear, Color.magenta, time * settime);
            }
            if (time >= settime)
            {
                setok = true;
            }
        }
        else
        {
            GameObject player = GameObject.FindWithTag("Player");
            float length = (player.transform.position - this.transform.position).magnitude;
            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton0)) && length<=recoverlength)
            {

                time2 += Time.deltaTime;
            }
            else {
                time2 -= Time.deltaTime;
                if(time2<=0)
                {
                    time2 = 0;
                }
            }

            if (!Cflag)
                GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.magenta, Color.white, time2 * recovertime);

            if (GetComponent<Renderer>().material.color == Color.white)
            {
                Cflag = true;
                recovercount++;

                if (!m_Audio.isPlaying)
                {
                    m_Audio.Play();
                    Destroy(this.gameObject, m_Audio.clip.length);
                }
            }
        }
    }

    public static int GetScore()
    {
        return recovercount;
    }

}
