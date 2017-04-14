using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

	public GameObject AnimationCheckpoint;
	public GameObject lightBaccon;
	// Use this for initialization
	void Start () {
		lightBaccon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void StartAnimation()
	{
		lightBaccon.SetActive(true);
		AnimationCheckpoint.SendMessage("AnimationCheckpoint");

	}
}
