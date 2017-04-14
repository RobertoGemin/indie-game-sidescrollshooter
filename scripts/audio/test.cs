using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public AudioSource audioSource;
	float hSliderValue = 0.5f;

	public AudioClip audio1;
	public AudioClip HitObject;
	public AudioClip HitEnemyAudio;
	public AudioClip gameOver;
	public AudioClip ShootGunAudio;
	public AudioClip JumpAudio;
	public AudioClip EnemyDieAudio;
		// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Audio>().playMusic(audio1);
	}

	void Update() {
		//Debug.Log ( audioSource.volume );
	}

	/*void OnGUI(){
		audioSource.volume = hSliderValue;
		hSliderValue = GUI.HorizontalSlider ( new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 1.0f);
		GUI.Label ( new Rect( 100, 100, 200, 200), "Value=" + hSliderValue);

		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		//if(GUI.Button (new Rect( 300, 400, 150, 50), "Audio2")) this.gameObject.GetComponent<Audio>().playSound(audio2);
		if(GUI.Button (new Rect( 300, 500, 150, 50), "Stop Music")) this.gameObject.GetComponent<Audio>().stopMusic();
	}*/


	void EnemyCollison(){ this.gameObject.GetComponent<Audio>().playSound(HitObject); }
	void BulletDestroy(){ this.gameObject.GetComponent<Audio>().playSound(HitObject); }
	void BulletHitEnemy(){
		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		this.gameObject.GetComponent<Audio>().playSound(HitEnemyAudio);
		
	}

	void ShootGun(){
		this.gameObject.GetComponent<Audio>().playSound(ShootGunAudio);
	}
	void JumpPlay(){
		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		this.gameObject.GetComponent<Audio>().playSound(JumpAudio);
		
	}
	void Normal(){
		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		this.gameObject.GetComponent<Audio>().Normalspeed();
		
	}
	void Slow(){
		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		this.gameObject.GetComponent<Audio>().SlowDown();
		
	}


	//
	void GameOver(){
		//if(GUI.Button (new Rect( 300, 300, 150, 50), "Audio1 + Loop")) this.gameObject.GetComponent<Audio>().playMusic(audio1);
		this.gameObject.GetComponent<Audio>().stopMusic();
		this.gameObject.GetComponent<Audio>().playSound(gameOver);	
	}
	void EnemyDie(){
		this.gameObject.GetComponent<Audio>().playSound(EnemyDieAudio);
	}

	
}
