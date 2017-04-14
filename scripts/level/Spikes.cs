using UnityEngine;
using System.Collections;

public class Spikes : Traps {
	public GameObject shakeCamera;
	// Use this for initialization
	void Start () {
		shakeCamera = GameObject.Find("Main Camera");
		damage = 8;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Activate( PlayerModel player ){
		shakeCamera.SendMessage("cameraShake");
		player.getDamage( damage );
		//Destroy(this.gameObject);
	}
}
