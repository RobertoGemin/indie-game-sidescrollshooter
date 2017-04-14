using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	private bool _loop = false;
	public bool slowdown = false;
	public float speed = 0f;
	public void playMusic(AudioClip audioClip){

		Debug.Log ("PlayMusic");
		
		if(GetComponent<AudioSource>().isPlaying == false)
		{
			//audio is not playing yet
			//_loop = true;
			GetComponent<AudioSource>().loop = true;
			GetComponent<AudioSource>().clip = audioClip;
			GetComponent<AudioSource>().Play( );
			//loopMusic( audioClip );
		}
		else
		{
			//audio is playing so stop that first
			stopMusic();
			playMusic( audioClip );
		}
	}


	void Update()
	{
		if(slowdown)
		{
		
			speed = Mathf.Lerp(speed, 0.3f, 0.1f);		
			GetComponent<AudioSource>().pitch = speed;
			GetComponent<AudioSource>().volume = speed;

		}

	}

	public void SlowDown(){

		slowdown = true;
		speed =1;
		//audio.pitch = 0.3f;
	}
	public void Normalspeed(){

		GetComponent<AudioSource>().volume = 1;
		slowdown = false;
		GetComponent<AudioSource>().pitch = 1.0f;
	}


	public void playSound(AudioClip audioClip){
		Debug.Log ("PlaySound");

		GetComponent<AudioSource>().PlayOneShot( audioClip );
	}

	public void stopMusic(){
		//_loop = false;
		GetComponent<AudioSource>().loop = false;
		GetComponent<AudioSource>().Stop();
	}

	public void stopSound(){
		GetComponent<AudioSource>().Stop();
	}
}
