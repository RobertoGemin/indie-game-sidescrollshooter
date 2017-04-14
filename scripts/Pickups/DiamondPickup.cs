using UnityEngine;
using System.Collections;

public class DiamondPickup: Pickup{
	
	// Use this for initialization
	void Start () {
		amount = 100;
		diamondAmount = 1;
	}
	
	void Update(){
		// Rotate Pickup & move up & down
		this.gameObject.transform.Rotate(Vector3.up);
	}
	
	public void Activate(PlayerModel player){
		player.addScore( amount);
		player.gameObject.GetComponent<IngameShop>().addDiamonds( diamondAmount );
		Destroy(this.gameObject);
	}
}
