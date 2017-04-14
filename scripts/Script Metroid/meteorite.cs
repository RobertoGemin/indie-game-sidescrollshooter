using UnityEngine;
using System.Collections;

public class meteorite : MonoBehaviour {

	public GameObject particle;
	private Vector3 rotation;
	public float rotRange;
	public GameObject shakeCamera;

	// Use this for initialization
	void Start () {
		rotation = new Vector3(Random.Range(-rotRange, rotRange), Random.Range(-rotRange, rotRange), Random.Range(-rotRange, rotRange));
		//rigidbody2D.velocity = new Vector2(-3f, -13f);
		if(GetComponent<Rigidbody2D>()) GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, -16f);
		shakeCamera = GameObject.Find("Main Camera");

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(rotation*Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		Vector2 checkVec = new Vector2(transform.position.x-2f, transform.position.y-2f);
		Vector2 checkVec2 = new Vector2(transform.position.x+2f, transform.position.y+2f);
		//Collider2D isGrounded = Physics2D.OverlapArea(checkVec, checkVec2).collider2D;
		Collider2D[] colliders = Physics2D.OverlapAreaAll(checkVec, checkVec2);
		foreach(Collider2D coll in colliders){
			if(coll.gameObject.layer == 8 || coll.gameObject.layer == 9){
				coll.gameObject.SendMessage("isDamaged", 8, SendMessageOptions.DontRequireReceiver);
			}
		}
		Instantiate(particle, this.transform.position, Quaternion.identity);
		shakeCamera.SendMessage("cameraShake");

		Invoke("die", 3f);
		this.transform.position = new Vector3(-100f, 0f, 0f);

		//particlessss
	}

	private void die(){
		Destroy(this.gameObject);
	}

}
