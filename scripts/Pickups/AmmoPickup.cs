using UnityEngine;
using System.Collections;

public class AmmoPickup : Pickup {

	// Use this for initialization
	void Start () {
		amount = 10;
	}

	void Update(){
		// Rotate Pickup & move up & down
		this.gameObject.transform.Rotate(Vector3.forward);
	}

	// Update is called once per frame
	void Activate (PlayerModel player) {
		player.addAmmo(amount);
		
		Destroy(this.gameObject);
	}
}