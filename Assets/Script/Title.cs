using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {


    public string nextSceneName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))//Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Main");
        }

    }
}
