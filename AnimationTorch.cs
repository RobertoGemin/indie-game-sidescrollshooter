using UnityEngine;
using System.Collections;

public class AnimationTorch : MonoBehaviour {
	public Animator animatorTorch;

	// Use this for initialization
	void Start () {
		animatorTorch = GetComponent <Animator>();
		animatorTorch.SetInteger("Torch",0);
	}
	
	// Update is called once per frame
	void AnimationCheckpoint () {
		animatorTorch.SetInteger("Torch",1);
	}
}
