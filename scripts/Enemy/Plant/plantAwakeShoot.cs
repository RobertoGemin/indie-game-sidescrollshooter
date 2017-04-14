using UnityEngine;
using System.Collections;

public class plantAwakeShoot : MonoBehaviour {
	private GameObject shakeCamera;

	public GameObject PlantBullet;
	public bool	plantAwake = false;
	public bool	plantDeath = false;
	private Quaternion direction = Quaternion.identity;
	public GameObject PlantAnimatorMove;
	public float posistionY = 3 ;
	private bool stateShootPlayer = false;
	public int damageToPlayer = 2;
	public float health = 40f;
	public Color collideColor = Color.red;
	public Color normalColor;
	public Transform GetTexture;
	public GameObject particlePlant;

	// Use this for initialization
	void Start() {
		normalColor = GetTexture.transform.GetComponent<Renderer>().material.color;
		shakeCamera = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			stateShootPlayer = true;
			InvokeRepeating("shoot",1f,1.2f); 
		}
		//Debug.Log(" >>>> _" + col.gameObject.name);
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			stateShootPlayer = false;
			CancelInvoke("shoot");
			//returnBase = true;
		}
		//Debug.Log(" >>>> _" + col.gameObject.name);
	}
	void AwakePlanet()
	{

		if (plantAwake == false)
		{
			PlantAnimatorMove.SendMessage("AnimationAwakePlant");
			plantAwake = true;
			direction = Quaternion.Euler(0f, 0f, 0f);
			InvokeRepeating("shoot",1f,1.2f); 
		}
		else 
		{
			//start animation..

		}
	}
	void Activate( PlayerModel player ){
		shakeCamera.SendMessage("cameraShake");
		player.getDamage( damageToPlayer );
	}


	public IEnumerator HitByBullet(){
		setHealth(-10f);
		GetTexture.transform.GetComponent<Renderer>().material.color = collideColor;
		yield return new WaitForSeconds(0.25f);
		GetTexture.transform.GetComponent<Renderer>().material.color = normalColor;
	}

	private void setHealth(float value){
		health += value;
		if(health <= 0f)
		{

			Instantiate(particlePlant, transform.position, Quaternion.identity);

			isDeath ();
			
		}
	}





	void isDeath ()
	{
		plantDeath = true;
		PlantAnimatorMove.SendMessage("AnimationDeadPlant");
		this.transform.GetComponent<Collider2D>().enabled = false;
		//this.transform.collider2D.enabled = false;


	}

	void shoot()
	{
		if (plantDeath == false)
		{
			Instantiate(PlantBullet,new Vector3(transform.position.x,transform.position.y+posistionY,transform.position.z), direction);


		}


	}
}
