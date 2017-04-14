using UnityEngine;
using System.Collections;

public class changeTexture : MonoBehaviour {

	// Use this for initialization
	public Material live;
	public Material Death;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material =live;
	}
	
	// Update is called once per frame
	
	void ChangeMaterial()
	{
		GetComponent<Renderer>().material =Death;
		
	}
}

