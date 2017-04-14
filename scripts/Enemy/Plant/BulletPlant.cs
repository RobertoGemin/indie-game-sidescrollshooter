using UnityEngine;
using System.Collections;

public class BulletPlant : MonoBehaviour {

	// Use this for initialization
	public float force = 20f;
	// Use this for initialization
	public GameObject PlayAudio;
	public GameObject  player;
	void Start () {
		PlayAudio = GameObject.Find("Audio");
		player = GameObject.Find("Player");
		GetComponent<Rigidbody2D>().velocity = -transform.right*force;		//give the bullet speed in his direction
		Destroy(this.gameObject,1.0f);
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player")
		{
			PlayAudio.SendMessage("EnemyDie");
			player.gameObject.SendMessage("getDamage", 1);		
			Destroy(this.gameObject);
		}
	}
}
