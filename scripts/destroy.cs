using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
	public float time=0.75f;
	// Use this for initialization
	void Start () {
	
		Destroy(this.gameObject,time);
	}
	
	// Update is called once per frame

}
