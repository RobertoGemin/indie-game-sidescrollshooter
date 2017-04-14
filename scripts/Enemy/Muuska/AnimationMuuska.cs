using UnityEngine;
using System.Collections;

public class AnimationMuuska : MonoBehaviour {
	public Animator animatormuska;
	public int animation=0;
	// Use this for initialization
	void Start () {
		animatormuska = GetComponent <Animator>();
		animatormuska.SetInteger("Muuska",0);
	}
	
	// Update is called once per frame
	void Update () {

		//animatormuska.SetInteger("Muuska",animation);
	
	}
	void AnimationAwakeMuuska()
	{
		//Debug.Log("Muuska bakbakab");
		animatormuska.SetInteger("Muuska",1);

	}
	void AnimationDeath()
	{
		
		animatormuska.SetInteger("Muuska",2);
		
	}
	void SleepMode()
	{
		
		animatormuska.SetInteger("Muuska",0);
		
	}
}
