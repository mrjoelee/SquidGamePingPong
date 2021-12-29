using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2AI : MonoBehaviour
{
    public float movementSpeed;
    //ball to follow
    public GameObject ball;

    private void FixedUpdate()
    {
        //check where is the ball - abs (doesn't matter it will be positive, returns a static float, transforming the position of myself. 
        //y value of player - the ball
        if(Mathf.Abs(this.transform.position.y - ball.transform.position.y) > 50)
        {
            //check if the ball is higher than the racket
            if(transform.position.y < ball.transform.position.y)
            {
                //if the ball is further than 50 points higher, than please move the racket up
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
            }
            else
            {    ////if the ball is further than 50 points higher, than please move the racket down
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
            }
        }
        else
        {   //if the if statement is false, than don't move at all
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
