using UnityEngine;
using System.Collections;

public class Gun : Weapon {
	public GameObject _bullet;
	private Quaternion direction = Quaternion.identity;
	public int upgrade = 0;
	// Use this for initialization
	void Start () {
		_power = 5;
		_time = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(direction);
		upgrade = (0 + IngameShop._bulletsUpgrade);
	}
	
	public void Rotate(float dir){
		if(dir == -1f) direction = Quaternion.Euler(0f, 0f, 0f);
		if(dir == 1f) direction = Quaternion.Euler(0f, 0f, 180f);
		
	}
	private void shoot(){
		Quaternion tempDir = direction;
		switch(upgrade){
		case 0: 
			Instantiate(_bullet, transform.position, tempDir);
			break;
		case 1:
			for(int i = 0; i<2; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-5f+(i*10));
				Instantiate(_bullet, transform.position, tempDir);
			}
			break;
		case 2:
			for(int i = 0; i<3; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-10f+(i*10));
				Instantiate(_bullet, transform.position, tempDir);
			}
			break;
		case 3:
			for(int i = 0; i<4; i++){
				tempDir = Quaternion.Euler(0f, 0f, direction.eulerAngles.z-15f+(i*10));
				Instantiate(_bullet, transform.position, tempDir);
			}
			break;
		}
		
	}
	override public void Activate(Character aChar){
		shoot();
		aChar.Invoke("shootDelay", _time);
		//Invoke("deactivate", _time);
	}
	
	private void deactivate(){
		
	}
}
