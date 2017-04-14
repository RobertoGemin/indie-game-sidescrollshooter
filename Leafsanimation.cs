using UnityEngine;
using System.Collections;

public class Leafsanimation : MonoBehaviour {

	public bool _horizontal;
	public float _platformSpeed;
	public float _moveDistance = 1;		//SPECIFY Movement amount
	public Vector3 _startPoint;
	
	public int _direction = 2;			// 1 = towards end, 2 = towards start
	
	private Vector3 _movement;
	public PlayerModel followPlayer;
	public bool PlayerIsOnPlatform;
	public bool MovePlatform = false;
	public GameObject player;	
	public float _endPoint;
	void Start () {

		_startPoint = this.transform.position;//new Vector3( this.transform.position.x,)
		PlayerIsOnPlatform = false;
		_endPoint = (_startPoint.y + _moveDistance);
	}
	
	// Update is called once per frame
	void OnCollisionExit2D(Collision2D coll)
	{		

		if(coll.gameObject.tag == "Player")
		{
			Debug.Log("False Player");
			//			_direction == 2

			PlayerIsOnPlatform = false;
			
		}
	}
	void OnCollisionStay2D( Collision2D coll ){
		if(coll.gameObject.tag == "Player")
		{
//			_direction == 2
			PlayerIsOnPlatform = true;
			
		}

		
	}


	void Update () {
		if(PlayerIsOnPlatform == true)
		{
			moveDown();
		}
		else
		{
			//_direction = 1;
			moveBack();

		}
		//if( _horizontal == false) 	moveVertical();
	}
	private void moveDown()
	{
		//float _endPoint = (_startPoint.y + _moveDistance); // How far ABOVE of the start point of the platform!

		if(_direction == 2){
			// move from end to start		// TOP to BOTTOM
			this.transform.position += new Vector3(0.0f, -_platformSpeed,0.0f);
			_movement = new Vector3(0.0f, -_platformSpeed,0.0f);
			followPlayer.moveOnPlatform(_movement );
			if(this.transform.position.y <= _startPoint.y) _direction = 1;
		}

	}
	private void moveBack()
	{
			if(_direction == 1){
			// move from start to end		// BOTTOM to TOP
			this.transform.position += new Vector3(0.0f, _platformSpeed,0.0f);
			_movement = new Vector3(0.0f, _platformSpeed,0.0f);
			if(this.transform.position.y >= _endPoint) _direction = 2;
		}
	}




		private void moveVertical(){
		float _endPoint = (_startPoint.y + _moveDistance); // How far ABOVE of the start point of the platform!
		
		if(_direction == 1){
			// move from start to end		// BOTTOM to TOP
			this.transform.position += new Vector3(0.0f, _platformSpeed,0.0f);
			_movement = new Vector3(0.0f, _platformSpeed,0.0f);
			if(this.transform.position.y > _endPoint) _direction = 2;
		}
		if(_direction == 2){
			// move from end to start		// TOP to BOTTOM
			this.transform.position += new Vector3(0.0f, -_platformSpeed,0.0f);
			_movement = new Vector3(0.0f, -_platformSpeed,0.0f);
			if(this.transform.position.y < _startPoint.y) _direction = 1;
		}
	}
	
	public void Activate( PlayerModel player ){
//		MovePlatform = true;
		//followPlayer = player;
		//player.moveOnPlatform( _movement );
	}

}
