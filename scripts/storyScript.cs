using UnityEngine;
using System.Collections;

public class storyScript : MonoBehaviour {
	public GUITexture screen;
	public Texture[] storyTextures;
	private int page = 0;
	// Use this for initialization
	void Start () {
		screen = GetComponent<GUITexture>();
		screen.texture = storyTextures[page];
		//screen.renderer.material.SetTexture(0, storyTextures[page]);
		page++;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3)){	//A){
			if(page < storyTextures.Length-1){
				screen.texture = storyTextures[page];
				page++;
			} else{
				screen.texture = storyTextures[page];

				Application.LoadLevel(2);
			}
		}
	}
}
