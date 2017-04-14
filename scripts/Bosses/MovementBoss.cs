using UnityEngine;
using System.Collections;

public class MovementBoss : MonoBehaviour {

	public float smooth;
	public bool check = false;
	public bool leftCheck = false;
	private Vector3 newPosition;
	private float newIntensity;
	private Color newColour;

	void Update () {
		
		if(check == true)
		{
			check = false;
			StartCoroutine("Animation");
		}

	}
	IEnumerator Animation() {
		StartCoroutine("DoSomething", 2.0F);
		yield return new WaitForSeconds(1);
		StopCoroutine("DoSomething");
		print("DoSomething stop");
		if(leftCheck == false)
		{
			leftCheck = true;
		}
		else
		{			
			leftCheck = false;
		}
		//transform.position =Vector2(16, 0) 
	}
	IEnumerator DoSomething(float someParameter) 
	{
		Vector2 positionA = new Vector3(-16, 0);
		Vector2 positionB = new Vector3(16, 0);
		while (true) {
			print("DoSomething Loop");
			if(leftCheck == false)
			{
			transform.position = Vector2.Lerp(transform.position, positionB, smooth * Time.deltaTime);
			}
			else
			{
                transform.position = Vector2.Lerp(transform.position, positionA, smooth * Time.deltaTime);
    		}
			yield return null;
			}
	    }
	}
/*
	
	// Update is called once per frame
	void Update () {
	
		Vector2 positionA = new Vector3(-16, 0);
		Vector2 positionB = new Vector3(16, 0);
		Vector2 positionC = new Vector3(7, 3);

 		if(leftCheck == false)
		{
			if (check == true)
			{
		    	transform.position = Vector2.Lerp(transform.position, positionB, smooth * Time.deltaTime);
				if (positionB.x > 15)
				{
					Debug.Log("positionB ");
					check =false ;
				}
				else{
					Debug.Log("else positionB ");
				}
			}
			else
			{
				transform.position = Vector2.Lerp(transform.position, positionA, smooth * Time.deltaTime);
				if (positionB.x > -15)
				{
					Debug.Log("positionBa");
					//check =true ;
				}
				else{
					Debug.Log("else positionA ");
				}
			}
		}
	}
}*/
