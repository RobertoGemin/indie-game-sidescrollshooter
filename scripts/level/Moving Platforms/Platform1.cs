using UnityEngine;
using System.Collections;

public class Platform1 : MovingPlatform {

	// Use this for initialization
	void Start () {
		_startPoint = this.transform.position;

		_horizontal = true;    	// True for Horizontal, False for Vertical Movement
		_platformSpeed = 0.05f;	// Specify Speed;
		_moveDistance = 5;		// Specify Travel Distance
	}
}
