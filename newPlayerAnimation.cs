using UnityEngine;
using System.Collections;

public class newPlayerAnimation : MonoBehaviour {

	public Animator animatorMove;
	// Use this for initialization
	void Awake(){
		
		animatorMove = GetComponent <Animator>();
	}
	
	void JumpAnimatie()
	{
		Debug.Log("Jump");
		animatorMove.SetInteger("walk",2);
	}
	
	void MovementAnimatie()
	{
		animatorMove.SetInteger("walk",1);
	}
	//
	void StandStillAnimatie()
	{
		animatorMove.SetInteger("walk",0);
	}
	void shootAnimatie()
	{
		animatorMove.SetInteger("walk",3);
	}
	void DeadAnimatie()
	{
		animatorMove.SetInteger("walk",4);
	}
}
