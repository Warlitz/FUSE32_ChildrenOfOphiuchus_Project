using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raigeki : MonoBehaviour {
	public float _DestroyTime = 3.0f;
	public Vector2 _InitialVelocity;

	//床のタグをつけてください
	public string _FloorTag;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (_InitialVelocity);
		Destroy (this.gameObject, _DestroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == _FloorTag)
			Destroy (this.gameObject);
	}
}
