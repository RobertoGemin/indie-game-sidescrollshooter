using UnityEngine;
using System.Collections;

public class Shotgun: Weapon {
	public GameObject _bullet;
	private Quaternion direction = Quaternion.identity;
	public int upgrade = 0;
	// Use this for initialization
	void Start () {
		_power = 10;
		_time = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(direction);
	}

	public void Rotate(float dir){
		if(dir == -1f) direction = Quaternion.Euler(0f, 0f, 0f);
		if(dir == 1f) direction = Quaternion.Euler(0f, 0f, 180f);
	
	}
	private void shoot(){
		Quaternion tempDir = direction;
		switch(upgrade){
		case 0: 
			for(int i = 0; i<10; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-20f+(i*4));	//bullet direction
				Instantiate(_bullet, transform.position, tempDir);						//instantiate one bullet
			}			
			break;
		case 1:
			for(int i = 0; i<2; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-5f+(i*10));	//bullet direction
				Instantiate(_bullet, transform.position, tempDir);						//instantiate one bullet
			}
			break;
		case 2:
			for(int i = 0; i<3; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-10f+(i*10));	//bullet direction
				Instantiate(_bullet, transform.position, tempDir);						//instantiate one bullet
			}
			break;
		}
	}
	override public void Activate(Character shootingChar){
		shoot();																		//shoot
		transform.GetComponent<Collider2D>().enabled = true;											//set indicater for gun has fired

		Invoke("deactivate", _time);													//reactivate gun 
	}

	private void deactivate(){
		transform.GetComponent<Collider2D>().enabled = false;
		transform.GetComponent<Renderer>().material.color = Color.gray;
		
	}
}
