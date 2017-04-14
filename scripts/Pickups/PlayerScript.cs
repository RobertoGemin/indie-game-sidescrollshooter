using UnityEngine;
using System.Collections;

//------------------------
//
//
//
//
//		THIS SCRIPT IS OLD>  ONLY Thing to maybe import = energy
//
//
//
//------------------------

public class PlayerScript : MonoBehaviour {

	protected const int MAXENERGY = 25;

	private float lastUpdate;

	private int playerHealth = 75;
	private int ammo = 10;
	private int energy = 0;

	private bool isBlocking = false;

	void Start () {	
		InvokeRepeating("regenEnergy", 1.0f, 0.4f); // Start Energy Regen
	}

	void Update() {
		if(Input.GetKey("d")) transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 15);
		if(Input.GetKey("a")) transform.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 15);

		//Blocking
		if(Input.GetKey("e")) {
			if(Time.time - lastUpdate >= 0.2f){		//Energy reduce timer.
				if (energy > 0) energy --;
				lastUpdate = Time.time;
			}
			if (energy > 0) blockStance();
			CancelInvoke();				// Cancel all invoke calls. ( Energy Regen )
		}
		if(Input.GetKeyUp("e")){
			InvokeRepeating("regenEnergy", 1.0f, 0.4f); //Restart Energy Regen #1st number is time after which it start #2nd number = interval time.
			isBlocking = false;
		}
	}

	void blockStance (){
		Debug.Log ( "Blocking" );
		isBlocking = true;
	}

	void regenEnergy(){
		if (energy < MAXENERGY){
			energy += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Pickup"){
			other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerScript>());		//Sends this script + the score script to the pickup
		}
	}

	public int getHealth (){
		return playerHealth;
	}
	
	public void addHealth ( int amount ){
		playerHealth += amount;
		if(playerHealth > 100) playerHealth = 100;
	}
	public void addAmmo ( int amount ){
		ammo += amount;
	}
	
	public void addScore( int amount){
		this.gameObject.GetComponent<Score>().addScore( amount);
		// Calls addscore inside the score script.
	}

	void OnGUI() {
		//PlayerHealth Damage Button
		if(GUI.Button( new Rect (Screen.width * 0.2f, Screen.height * 0.9f, Screen.width * 0.1f, Screen.height * 0.1f), "Hit Player")){
			playerHealth --;
		}
		//PlayerHealth Display
		GUI.Box( new Rect (0, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f), "Player Health \n \n" + playerHealth + " / 100");

		//Ammo
		GUI.Box( new Rect (Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f), "Ammo \n \n" + ammo);

		//Energy
		if (isBlocking == false) GUI.Box( new Rect (Screen.width * 0.4f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.05f), "Press E To Block");
		if (isBlocking == true) GUI.Box( new Rect (Screen.width * 0.4f, Screen.height * 0.85f, Screen.width * 0.2f, Screen.height * 0.05f), "Blocking Consumes your Energy");

		GUI.Box( new Rect (Screen.width * 0.4f, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f), "Energy \n \n" + energy);
	}
}
