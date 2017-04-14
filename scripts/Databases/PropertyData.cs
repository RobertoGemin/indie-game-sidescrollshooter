using UnityEngine;
using System.Collections;

public class PropertyData : MonoBehaviour {

    private float direction;
    private float lookDir;
    public GameObject pBullet;
    public GameObject eBullet;
    
    //Move: makes the designated GameObject move in the designated direction
    public void move(GameObject character, int dir, float maxSpeed, float speed)
    {
        if (dir > 0 && character.transform.GetComponent<Rigidbody2D>().velocity.x > maxSpeed) character.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, character.transform.GetComponent<Rigidbody2D>().velocity.y);
        if (dir < 0 && character.transform.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed) character.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, character.transform.GetComponent<Rigidbody2D>().velocity.y);

        character.transform.GetComponent<Rigidbody2D>().AddForce(dir * Vector2.right * speed);
        character.transform.localScale = new Vector3(dir, 1, 1);
    }

    //Jump: makes the designated GameObject jump up
    public void jump(GameObject character, float jumpSpeed)
    {
		character.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(character.transform.GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }

    //Crouch: makes the designated GameObject lie down (also while moving)
    public void crouch(GameObject character)
    {
        //Put in Dieter's Crouching code.
    }

    //Slash: makes the designated GameObject slash his sword
    public void slash(GameObject character)
    {
        //Put in Dieter's Slashing code.
    }

    //Shoot: makes the designated GameObject shoot bullets from his gun
    public void shoot(GameObject character, Transform gun)
    {
        if (character.name == "Player")
        {
            Instantiate(pBullet, gun.position, Quaternion.identity);
        }
        else
        {
            Instantiate(eBullet, gun.position, Quaternion.identity);
        }
    }

    //Block: makes the designated GameObject protect itsself from getting hurt.
    public void block(GameObject character)
    {
        //Put in Dieter's Blocking code.
    }

    //FallBack: makes the designated GameObject fall back a few steps after being hit
    public void fallBack(GameObject character)
    {
        //Put in Thomas's Enemy code or Dieter's Character code. At least one of the two should have this chunk of code. Ask around!
    }

    //Add: adds the first value to the second and returns it
    public float add(float v1, float v2)
    {
        return v1 + v2;
    }

    //Subtract: subtracts the first value from the second and returns it
    public float subtract(float v1, float v2)
    {
        return v1 - v2;
    }

    //Multiply: multiplies the first value with the second and returns it
    public float multiply(float v1, float v2)
    {
        return v1 * v2;
    }

    //Divide: divides the first value with the second and returns it
    public float divide(float v1, float v2)
    {
        return v1 / v2;
    }
}