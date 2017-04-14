using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject character;
	private bool cameraShouldFollow = true;
	public float cameraDistance; 
	public float cameraY; 
	public float duration = 1.0f;
	// Use this for initialization
	void Start () {
		character = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraShouldFollow == true)
		{
		Vector3 temp = character.transform.position;
		temp.x += 0;
		temp.y += cameraY;
		temp.z = -cameraDistance;
		this.transform.position = temp;
		}
	}
	void cameraShake()
	{
		StartCoroutine("Shake");
		cameraShouldFollow = false;
	}
	IEnumerator Shake() {

		float elapsed = 0.0f;
		float magnitude = 0.5f;
		
		Vector3 originalCamPos = this.transform.position;
		while (elapsed < duration) {
			Vector3 charPos = character.transform.position;

			originalCamPos = new Vector3(charPos.x + 0, charPos.y + cameraY, charPos.z - cameraDistance);
			elapsed += Time.deltaTime;
			float percentComplete = elapsed / duration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;
			if (Random.value < 0.5)
			{
			this.transform.position = new Vector3(originalCamPos.x + x , originalCamPos.y + y, originalCamPos.z);
			}
			else
			{
			this.transform.position = new Vector3(originalCamPos.x - x , originalCamPos.y - y, originalCamPos.z);
			}
		
			yield return null; 
		}
		cameraShouldFollow = true;
		this.transform.position = originalCamPos;

	} 


}
