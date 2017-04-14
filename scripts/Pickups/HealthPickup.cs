using UnityEngine;
using System.Collections;

public class HealthPickup : Pickup {

	// Use this for initialization
	void Start () {
		amount = 2;
	}

	void Update(){
		// Rotate Pickup & move up & down
		this.gameObject.transform.Rotate(Vector3.right);
	}

	public void Activate(PlayerModel player){
		if(player.getHealth() == 8) return;
		player.addHealth(amount);

		Destroy(this.gameObject);
	}
}
