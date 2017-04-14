using UnityEngine;
using System.Collections;

public class animationScript : MonoBehaviour {

	// Use this for initialization

	public void AnimationStop()
	{
		GetComponent<Animation>().Stop("animation Enemy");
	
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
