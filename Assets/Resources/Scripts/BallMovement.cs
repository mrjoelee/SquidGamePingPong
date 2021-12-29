using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
   

    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    //helper variable

    int hitCounter = 0;


    void Start()
    {
        StartCoroutine(this.StartBall());
    }
    //reposition the ball after scoring
    void PositionBall(bool isStartingPlayer1)
    {
        //reseting the velocity of hte ball
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    //call routine forces everything wait for it before action happens. 
    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        //wait for 2 second, then movement of the ball starts
        yield return new WaitForSeconds(2);

        if (isStartingPlayer1)
        {
            //move to the left
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            //move to the right
            this.MoveBall(new Vector2(1, 0));
        }
    }

    //method indicating on how fast the ball should move
    public void MoveBall(Vector2 dir)
    {
        //direction with a magnitude of 1 
        dir = dir.normalized;

        //this will give the actual speed of the ball 
        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        //to apply the speed to the ball
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

        //whatever the direction of the ball will times the speed to the get the movement
        rigidBody2D.velocity = dir * speed;

    }

    //increaseing the hitcounter by +1
    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
    

   
}
