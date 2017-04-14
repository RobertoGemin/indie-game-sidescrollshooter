using UnityEngine;
using System.Collections;

public class MeteorSpawn : MonoBehaviour {
	public bool activated = true;
	public GameObject meteor;
	private GameObject thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find("Player");
		if(activated) InvokeRepeating("spawnMeteors", 1f, 2f);
		//Invoke ("die", 10f);
	}

	private void spawnMeteors(){
		Vector3 pPos = thePlayer.transform.position;
		float randomX = Random.Range(-5f, 7f);
		float randomY = Random.Range(-2f, 2f);
		Vector3 mPos = new Vector3(pPos.x +randomX, 25f+randomY, pPos.z+5f);

		GameObject theMeteor = Instantiate(meteor, mPos, Quaternion.identity) as GameObject;
		theMeteor.transform.parent = transform;
	}

	 void die(){
		Destroy(this.gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
