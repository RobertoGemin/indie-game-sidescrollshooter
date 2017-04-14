using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	protected int _speed;
	protected int _jumpSpeed;
	protected bool _canJump;
	protected bool _canAttack;
	protected bool _canShoot;
	protected float _maxSpeed;
	protected Transform _weapon;
	protected Transform _gun;
	protected PropertyData data;

	protected Vector3 startPosition;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	virtual public void shootDelay(){

	}
}
