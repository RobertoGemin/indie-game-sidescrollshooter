using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	public Animator animatorMove;
	// Use this for initialization
	void Awake(){

		animatorMove = GetComponent <Animator>();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
		 if(Input.GetKeyDown("d")) 
		{
			animatorMove.SetInteger("walk",1);
		}
		if(Input.GetKeyDown("s")) 
		{
			animatorMove.SetInteger("walk",0);
			
		}
		if(Input.GetKeyDown("a")) 
		{
			animatorMove.SetInteger("walk",1);
			
		}
		if(Input.GetKeyDown("w")) 
		{
			animatorMove.SetInteger("walk",2);
		}
		if(Input.GetKeyDown("z")) 
		{
			animatorMove.SetInteger("walk",3);
		}
	}*/
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

	//MovementAnimatie
}
