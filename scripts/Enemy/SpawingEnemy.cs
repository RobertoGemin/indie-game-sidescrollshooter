using UnityEngine;
using System.Collections;

public class SpawingEnemy : MonoBehaviour {

	public GameObject enemy;

	void Start () {
		//transform.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate( PlayerModel player ){
		Transform child = transform.GetChild(0);
		Instantiate(enemy,new Vector3(child.position.x, child.position.y , child.position.z) , Quaternion.identity);
		Destroy(this.gameObject);
	}



}
