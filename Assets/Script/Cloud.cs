using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	public float _SideRange = 10;
	public float _VerticalRange = 2;
	public float _MoveSpeed = 1;
	public float _VerticalSpeed = 1;
	public GameObject _raigeki;
	public float _raigekiInterval = 1;

	public enum MoveMode {Basic,Sin};
	public MoveMode _MoveMode;
	public enum ShotMode{Vertical,Horizontal};
	public ShotMode _ShotMode;
	public enum Direction{Left,Right};
	public Direction _Direction;

	private Vector2 _StartPos;
	private int _sign = 1;
	private float _intervalTime = 0.0f;
	private float _time = 0;
	// Use this for initialization
	void Start () {
		_StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		switch(_MoveMode)
		{
		case MoveMode.Basic:
			BasicMove ();
			break;
		case MoveMode.Sin:
			SinMove ();
			break;
		}
		switch (_ShotMode) {
		case ShotMode.Vertical:
			VerticalShot ();
			break;
		case ShotMode.Horizontal:
			HorizonShot ();
			break;
		}
	}

	void BasicMove()
	{
		switch (_ShotMode) {
		case ShotMode.Vertical:
			transform.Translate (new Vector2 (_MoveSpeed * Time.deltaTime * _sign, 0));
			break;
		case ShotMode.Horizontal:
			transform.Translate (new Vector2 (0,_MoveSpeed * Time.deltaTime * _sign));
			break;
		}

		if (transform.position.x > _StartPos.x + _SideRange || transform.position.y > _StartPos.y + _SideRange) 
			_sign = -1;		
		else if(transform.position.x < _StartPos.x - _SideRange || transform.position.y < _StartPos.y - _SideRange)
			_sign = 1;
	}

	void SinMove()
	{
		_time += Time.deltaTime * 360;
		float f = Mathf.Sin (_time * Mathf.Deg2Rad);
		switch (_ShotMode) {
		case ShotMode.Vertical:
			transform.Translate (new Vector2 (_MoveSpeed * Time.deltaTime * _sign, f * _VerticalRange * Time.deltaTime * _VerticalSpeed));
			break;
		case ShotMode.Horizontal:
			transform.Translate (new Vector2 (f * _VerticalRange * Time.deltaTime * _VerticalSpeed,_MoveSpeed * Time.deltaTime * _sign));
			break;
		}

		if (transform.position.x > _StartPos.x + _SideRange || transform.position.y > _StartPos.y + _SideRange) 
			_sign = -1;		
		else if(transform.position.x < _StartPos.x - _SideRange || transform.position.y < _StartPos.y - _SideRange)
			_sign = 1;
	}

	void VerticalShot()
	{
		_intervalTime += Time.deltaTime;

		if (_intervalTime > _raigekiInterval) {
			_intervalTime = 0;
			GameObject obj = Instantiate (_raigeki, transform.position, Quaternion.identity) as GameObject;
		}
	}

	void HorizonShot()
	{
		_intervalTime += Time.deltaTime;

		if (_intervalTime > _raigekiInterval) {
			_intervalTime = 0;
			GameObject obj = Instantiate (_raigeki, transform.position, _raigeki.transform.rotation) as GameObject;
			obj.GetComponent<Rigidbody2D> ().gravityScale = 0;
			switch (_Direction) {
			case Direction.Left:
				obj.GetComponent<raigeki> ()._InitialVelocity *= -1;
				break;
			case Direction.Right:
				break;
			}
		}
	}
}
