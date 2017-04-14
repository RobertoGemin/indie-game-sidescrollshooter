 using UnityEngine;
using System.Collections;

public class PlantCollider : Traps {
	private GameObject shakeCamera;
	public bool PlantLives = false;
	public GameObject PlantAnimatorMove;
	public GameObject stopshooting;
	public GameObject stopJumping;
	public float health = 40f;
	public int damageToPlayer = 2;
	public GameObject particleBlob;
	private Color collideColor = Color.red;
	private Color normalColor;


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
	}
	void DiePlant()
	{
		//stopshooting.SendMessage("isDeath");
		this.transform.GetComponent<Collider2D>().enabled = false;
		//this.transform.GetComponent<

		PlantAnimatorMove.SendMessage("AnimationDeadPlant");


	}
}
