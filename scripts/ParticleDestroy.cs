using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
	public float sec = 2f;
	// Use this for initialization
	void Start () {
		Invoke("die", sec);
	}

	private void die(){
		Destroy(this.gameObject);
	}
	// Update is called once per frame
	void Update () {
	}
}
