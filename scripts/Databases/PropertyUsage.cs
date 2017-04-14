using UnityEngine;
using System.Collections;

public class PropertyUsage : Character {

	// Use this for initialization
	void Start() {
        data = GameObject.Find("DataManager").GetComponent<PropertyData>();
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            data.move(gameObject, -1, _maxSpeed, _speed);
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            data.move(gameObject, 1, _maxSpeed, _speed);
        }
	}
}
