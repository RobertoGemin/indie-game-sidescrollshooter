using UnityEngine;
using System.Collections;

public class ArtifactColider : MonoBehaviour {
	public Transform ArtifactAnimation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void goNextScene(){
		Application.LoadLevel("protypeLevel2");
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name == "Player"){
			//stateFollowPlayer = true;
			ArtifactAnimation.SendMessage("OpenDoor");
			//GetComponent<ArtifactAnimation>().SendMessage
	//	GetComponent<MuuskaCollison>().HitByBullet();
			Invoke("goNextScene", 2.5f); 

		
		}
		//Debug.Log(" >>>> _" + col.gameObject.name);
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name == "Player"){
		//	stateFollowPlayer = false;
		//	returnBase = true;
		//ArtifactAnimation.SendMessage("CloseDoor");
		//	animationMuuska.SendMessage("SleepMode");
			
		}
	
	}
}
