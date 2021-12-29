using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    //creating a method to collion of ball movement

    public BallMovement ballMovement;
    public ScoreController scoreController;
    void BounceFromRacket(Collision2D c)
    {
        //poisition of ball
        Vector3 ballPosition = this.transform.position;

        //racket position
        Vector3 racketPosition = c.gameObject.transform.position;

        // height of racket
        float racketHight = c.collider.bounds.size.y;

        //bounce from player 1 or player 2 (change of direction of the ball)

        float x;
        if(c.gameObject.name == "RacketPlayer1")
        {
            // to the right 
            x = 1;
        }
        else
        {
            x = -1;
        }

        //calculate y - creating a new direction when it goes to player 2, high it should go toward the bottom or to the top.
        float y = (ballPosition.y - racketPosition.y) / racketHight;

        //increase the hitcounter and the speed of the ball
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
           
    }
    //when the ball collides with something, there will be a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "WallLeft")
        {
            Debug.Log("Collision with WallLeft");
            this.scoreController.GoalPlayer2();
            //once it hits the left wall start the ball oon the right side
            StartCoroutine(this.ballMovement.StartBall(false));
        }
        //will give a score for player 1
        else if(collision.gameObject.name == "WallRight")
        {
            Debug.Log("Collision with WallRight");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
    }

}

