using UnityEngine;
using System.Collections;

public class AnimationControlPlant : MonoBehaviour {
	public Animator animatorPlant;
	public GameObject deathplant;
	// Use this for initialization
	void Awake(){
		
		animatorPlant = GetComponent <Animator>();
	}
	void AnimationAwakePlant()
	{
		animatorPlant.SetInteger("Plant",1);
	}

	void AnimationDeadPlant()
	{
		animatorPlant.SetInteger("Plant",2);
		deathplant.gameObject.SendMessage("ChangeMaterial");

	}
}
