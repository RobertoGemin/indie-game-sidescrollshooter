using UnityEngine;
using System.Collections;

public class ArtifactAnimation : MonoBehaviour {

	public Animator animatorArtifact;
	public int animation=0;
	// Use this for initialization
	void Start () {
		animatorArtifact = GetComponent <Animator>();
		animatorArtifact.SetInteger("Animation",0);
	}
	
	// Update is called once per frame
	void OpenDoor()
	{
		
		animatorArtifact.SetInteger("Animation",1);
		
	}
	void CloseDoor()
	{
		
		animatorArtifact.SetInteger("Animation",0);
		
	}
}
