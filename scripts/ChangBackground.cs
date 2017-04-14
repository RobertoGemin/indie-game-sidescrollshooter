using UnityEngine;
using System.Collections;

public class ChangBackground : MonoBehaviour {

	public Material Dark;
	public Material Light;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material =Dark;

	}
	
	// Update is called once per frame
	
	void ChangeMaterial()
	{
		Debug.Log("ChangeMaterial");
		GetComponent<Renderer>().material =Light;
		
	}
}
