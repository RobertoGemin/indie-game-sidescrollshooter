using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	private int score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void addScore ( int value) {
		score += value; 
	}
	
	void OnGUI(){
		//GUI.Box( new Rect (0, 0, Screen.width * 0.2f, Screen.height * 0.1f), "Score \n \n" + score);
		GUI.Label ( new Rect ( Screen.width * 0.75f , Screen.height * 0.01f, Screen.width * 2.1f, Screen.height * 0.1f), "Score: " + score);
		//GUI.Label 			( new Rect ( Screen.width * 0.75f	, Screen.height * 0.11f, Screen.width * 2.1f, Screen.height * 0.1f), "Diamonds: \n " + _diamonds);

	}
}
