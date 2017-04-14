using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	private float screenW;
	private float screenH;
	private Rect camW;
	private float camH;

	// Use this for initialization
	void Start () {
		screenW = Screen.width;
		screenH = Screen.height;
		//Debug.Log(camera.pixelRect);
		GetComponent<Camera>().pixelRect = new Rect(0f, 0f, 1018f, 494f);
	}
	
	// Update is called once per frame
	void Update () {
		//camera.pixelRect = new Rect(0f, 0f, 618f, 494f);

	}
}
