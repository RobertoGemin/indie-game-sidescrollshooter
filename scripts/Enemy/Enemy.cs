using UnityEngine;
using System.Collections;

public class Enemy : Character {

    //private Vector2 run;
    public int health = 5;
    public int killReward = 1000;

	// Use this for initialization
	void Start() {
        _canJump = true;
        _canAttack = true;
        _canShoot = true;
        _speed = 20;
        _maxSpeed = 5f;
        _jumpSpeed = 8;
        _weapon = this.transform.GetChild(0);	//weapon
        _gun = this.transform.GetChild(1);	//gun
        data = GameObject.Find("DataManager").GetComponent<PropertyData>();
        //run = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update() {
        //Creating the numbers for the movements
        //int action = (int)randomize();
        
        ////Connecting the ints to the right movements
        //if (action <= 6)
        //{
        //    //Run
        //    //if (enemy.position.x > spaceMarine.position.x)
        //    //{
        //    //    run.x = -30;
        //    //}
        //    //else if(enemy.position.x < spaceMarine.position.x)
        //    //{
        //    //    run.x = 30;
        //    //}
        //    //else
        //    //{
        //    //    run *= 0;
        //    //}
        //    ////print(run);
        //    //data.move(gameObject, run, 90);
        //}
        //else if (action > 6 && action <= 10)
        //{
        //    //Shoot
        //    data.shoot(gameObject, _gun);
        //}
        //else if (action > 10 && action <= 13)
        //{
        //    //Jump
        //    data.jump(gameObject, _jumpSpeed);
        //}
        //else if (action > 13 && action <= 15)
        //{
        //    //Duck & Cover
        //    data.crouch(gameObject);
        //}
        //else if (action > 15)
        //{
        //    //Stand
        //}
    }

	void OnMouseDown(){
		isDamaged (1);
	}

	void isDamaged (int amount){
		health -= amount;
		scaleHealth();
		if(health <= 0){
			// die function
			isDead();
		}
	}

	void scaleHealth(){
		this.gameObject.transform.FindChild("Health").transform.localScale = new Vector3((1.0f * (health/5.0f)), 0.1f, 0.1f);
	}

	void isDead(){
		GameObject.Find("Player").GetComponent<Score>().addScore(killReward);
		Destroy(this.gameObject);
	}

    //Randomizer: returns a random number between 0 and 10
    //private float randomize()
    //{
    //    return Random.value * 20;
    //}
}
