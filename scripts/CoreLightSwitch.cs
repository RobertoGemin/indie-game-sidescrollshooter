using UnityEngine;
using System.Collections;

public class CoreLightSwitch : MonoBehaviour {

    public Light worldLight;
	public Light sunLight;
	public GameObject background1;
	public GameObject background2;
	public GameObject background3;
	public GameObject background4;
	public GameObject background5;
	public GameObject background6;
	public GameObject playerLight;
	public GameObject spaceship;

	public GameObject metriodSpawn;
	private Transform enemySpawnLight;
	// Use this for initialization
	public bool Showlight = false;
	void Start () {
		//spaceship.collider2D.enabled = false;
		enemySpawnLight = GameObject.Find("SpawnEnemyLight").transform;

		worldLight.enabled = true;//Core is shut down.
		sunLight.enabled = false;//Core is shut down.
		//backgroundDark.SetActive(false);//Core is shut down.
	}

	// Update is called once per frame
	void Update () {
	    
	}

    // Checks the collision once per frame
    public void Activate( PlayerModel player ){
		sunLight.enabled = true;
		Showlight = true;
		playerLight.transform.GetComponent<Light>().enabled = false;
		//playerLight.transform.com = false;
		//backgroundDark.SetActive(true);
		worldLight.enabled = false;
		metriodSpawn.SendMessage("die");
		spaceship.GetComponent<Collider2D>().enabled = true;
		background1.gameObject.SendMessage("ChangeMaterial");
		background2.gameObject.SendMessage("ChangeMaterial");
		background3.gameObject.SendMessage("ChangeMaterial");
		background4.gameObject.SendMessage("ChangeMaterial");
		background5.gameObject.SendMessage("ChangeMaterial");
		background6.gameObject.SendMessage("ChangeMaterial");

		for(int i = 0; i < enemySpawnLight.childCount; i++){
			enemySpawnLight.GetChild(i).GetComponent<Collider2D>().enabled = true;
		}
	}
}
