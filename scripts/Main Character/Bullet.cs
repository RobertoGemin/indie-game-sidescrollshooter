using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float force = 25f;
	// Use this for initialization
	public GameObject Explosion;
	public GameObject PlayAudio;
	void Start () {
		PlayAudio = GameObject.Find("Audio");
		GetComponent<Rigidbody2D>().velocity = -transform.right*force;		//give the bullet speed in his direction
		Destroy(this.gameObject,2.5f);

	}
	void Update(){
		//transform.Translate(Vector3.left*Time.deltaTime*force);
	}
	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Enemy"){
			PlayAudio.SendMessage("EnemyDie");
			col.gameObject.SendMessage("HitByBullet");
		}

		if(col.gameObject.tag == "Plant"){
			PlayAudio.SendMessage("EnemyDie");
			col.gameObject.SendMessage("HitByBullet");
		}

		if(col.gameObject.tag == "Muuska"){
			PlayAudio.SendMessage("EnemyDie");
			col.gameObject.SendMessage("HitByBullet");
		}


		if(col.gameObject.tag == "jemoeder"){
			Destroy(this.gameObject);
			//Destroy(col.gameObject);
			
		}
		if(col.gameObject.tag == "Boss"){
			Destroy(this.gameObject);
			//Destroy(col.gameObject);
			col.gameObject.GetComponent<Boss>()._isHit();
			
		}

		Instantiate (Explosion, transform.position, Quaternion.identity);
		PlayAudio.SendMessage ("BulletDestroy");
		Destroy(this.gameObject);
	}


	/*void OnColliderHit(Collision2D col){
		Debug.Log(col.gameObject.tag);
		if(col.gameObject.tag == "Enemy"){
			
			Destroy(col.gameObject);
		}
		Destroy(this.gameObject);
	}*/

}
