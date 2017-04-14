using UnityEngine;
using System.Collections;

public class EnemyAnimation2 : Character {
	
	public bool ShootAnimationcheck = false;
	public bool AnimationCheck = true;
	public bool JumpAnimationcheck = false;
	public float smooth = 2.0f;
	public int direction = 1;
	private Vector3 lastPos;
	private bool canBounce = true;
	public float health = 40f;
	public int damageToPlayer = 2;
	public GameObject particleBlob;
	private Color collideColor = Color.red;
	private Color normalColor;
	private float _sizeX;
	private float _sizeY;
	private float _sizeZ;
	// Use this for initialization
	void Start () {
		_sizeX = transform.localScale.x;
		_sizeY = transform.localScale.y;
		_sizeZ = transform.localScale.z;
		_canJump = true;
		_canShoot = true;
		_speed = 10;
		_maxSpeed = 5f;
		_jumpSpeed = 8;
		//_gun = this.transform.GetChild(1);	//gun
		AnimationCheck = true;
		//transform.renderer.material.color = Color.green;
		normalColor = transform.GetChild(0).transform.GetComponent<Renderer>().material.color;
	}
	public void setUp(int aDir){
		direction = aDir;
	}
	// Update is called once per frame
	void Update () {

		moveAI();
	}
	void OnCollisionEnter2D(Collision2D col){
		//if(canBounce){
			if(col.gameObject.name == "enemyPath"){
				//canBounce = false;
				direction *= -1;
				//transform.position = new Vector3(lastPos.x, transform.position.y, transform.position.z);
				transform.GetComponent<Rigidbody2D>().velocity = new Vector2(5f*direction, 0f);
				//Invoke("resetCanBounce", 0.1f);
			//}
		}
	}
	private void resetCanBounce(){
		canBounce = true;
	}
	private void moveAI(){
		move (direction);
	}
	void Activate( PlayerModel player ){
		player.getDamage(damageToPlayer);
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(7f*-direction, 0f);
	}
	
	public IEnumerator HitByBullet(){
		setHealth(-20f);
		transform.GetChild(0).transform.GetComponent<Renderer>().material.color = collideColor;
		yield return new WaitForSeconds(0.25f);
		transform.GetChild(0).transform.GetComponent<Renderer>().material.color = normalColor;
	}

	private void setHealth(float value){
		health += value;
		if(health <= 0f){
			Instantiate(particleBlob, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}


	private void shoot(){
		if(_canShoot){
			_gun.SendMessage("Activate");	
			_canShoot = false;
		}
	}
	private void move(int dir){

		if(dir > 0 && transform.GetComponent<Rigidbody2D>().velocity.x > _maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, transform.GetComponent<Rigidbody2D>().velocity.y);
		if(dir < 0 && transform.GetComponent<Rigidbody2D>().velocity.x < -_maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, transform.GetComponent<Rigidbody2D>().velocity.y);
		
		transform.GetComponent<Rigidbody2D>().AddForce(dir*Vector2.right*_speed); 
		transform.localScale = new Vector3(dir*_sizeX, _sizeY, _sizeZ);

		lastPos = transform.position;
	}
	
}
