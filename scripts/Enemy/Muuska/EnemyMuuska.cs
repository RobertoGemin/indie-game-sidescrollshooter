using UnityEngine;
using System.Collections;

public class EnemyMuuska : MonoBehaviour {

	public bool muuskaAwake;
	public GameObject  animationMuuska;
	public bool stateFollowPlayer = false;
	public bool returnBase = false;
	private float lastX;
	private float newStartTimer = 0f;
	private float _startX;
	private GameObject _player;
	private float _sizeX;
	private float _sizeY;
	private float _sizeZ;
	public float _speed = 6;
	public float _maxSpeed = 5;
	public int damageToPlayer = 2;
	public int direction = 1;
	private bool dead = false;

	void Start () {
		_sizeX = transform.localScale.x;
		_sizeY = transform.localScale.y;
		_sizeZ = transform.localScale.z;
		muuskaAwake = false;
		_startX = transform.position.x;
		_player = GameObject.Find("Player");
	}
	public void HitByBullet(){

		//transform.GetChild(0).SendMessage("HitByBullet");
		// dude child functie werkt niet om dat hele volgorder niet klopt.

		GetComponent<MuuskaCollison>().HitByBullet();
	}
	// d is called once per frame
	void Update () {
		if(!dead){
			if(!returnBase){
				if(stateFollowPlayer){
					if(_player.transform.position.x > transform.position.x+1) move(1);
					if(_player.transform.position.x < transform.position.x-1) move(-1);

				}
			}
			else {
				if(_startX > transform.position.x+1f) move(1);
				else if(_startX < transform.position.x-1f) move(-1);
				else {
					returnBase = false;
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			stateFollowPlayer = true;
		}
		//Debug.Log(" >>>> _" + col.gameObject.name);
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			stateFollowPlayer = false;
			returnBase = true;
			animationMuuska.SendMessage("SleepMode");

		}
		//Debug.Log(" >>>> _" + col.gameObject.name);
	}
	void Activate( PlayerModel player ){
		player.getDamage(damageToPlayer);
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(7f*-direction, 0f);
	}
	private void move(int dir){
		if(newStartTimer == 0f)lastX = transform.position.x;
		direction = dir;
		if(dir > 0 && transform.GetComponent<Rigidbody2D>().velocity.x > _maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(_maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
		if(dir < 0 && transform.GetComponent<Rigidbody2D>().velocity.x < -_maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-_maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
		
		transform.GetComponent<Rigidbody2D>().AddForce(dir*Vector2.right*_speed*(Time.deltaTime*100)); 
		transform.localScale = new Vector3(dir*_sizeX, _sizeY, _sizeZ);
		if (lastX < transform.position.x+0.1f && lastX > transform.position.x-0.1f && !stateFollowPlayer) {
						newStartTimer += Time.deltaTime;
						Debug.Log (newStartTimer);
						if (returnBase ) {
							if( newStartTimer > 2f){
								newStartTimer = 0f;
								_startX = transform.position.x;
							}
						}
				} else {
						newStartTimer = 0f;
				}
		
	}

	void MuuskaAwake()
	{

		
		if (muuskaAwake == false)
		{
			animationMuuska.SendMessage("AnimationAwakeMuuska");
			muuskaAwake = true;
	
		}

	}
	public void Die(){
		dead = true;
		transform.GetComponent<BoxCollider2D>().enabled = false;
		transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
	}


}
