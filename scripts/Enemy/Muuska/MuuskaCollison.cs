using UnityEngine;
using System.Collections;

public class MuuskaCollison : MonoBehaviour {

	public GameObject shakeCamera;
	public bool PlantLives = false;
	public GameObject AnimatorMuuska;
	public float health = 40f;
	public int damageToPlayer = 2;
	public GameObject particleBlob;
	public Color collideColor = Color.red;
	public Color normalColor;
	public Transform GetTexture;
	//public GameObject stopshooting;

	// Use this for initialization
	void Start () {
		normalColor = GetTexture.transform.GetComponent<Renderer>().material.color;
			//Color.white; //transform.GetChild(0).transform.renderer.material.color;
		shakeCamera = GameObject.Find("Main Camera");
		//damage = 8;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate( PlayerModel player ){
		shakeCamera.SendMessage("cameraShake");
;
	}


	public IEnumerator HitByBullet(){
		setHealth(-20f);
		GetTexture.transform.GetComponent<Renderer>().material.color = collideColor;
		yield return new WaitForSeconds(0.25f);
		GetTexture.transform.GetComponent<Renderer>().material.color = normalColor;
	}
	
	private void setHealth(float value){
		health += value;
		if(health <= 0f)
		{
			AnimatorMuuska.SendMessage("AnimationDeath");
			Instantiate(particleBlob, transform.position, Quaternion.identity);
			this.transform.GetComponent<Collider2D>().enabled = false;
			DieMuuska();
			this.SendMessage("Die");

		}
	}



	void DieMuuska()
	{
		transform.GetComponent<BoxCollider2D>().enabled = false;
		transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		AnimatorMuuska.SendMessage("AnimationDeath");
		
		
	}
}
