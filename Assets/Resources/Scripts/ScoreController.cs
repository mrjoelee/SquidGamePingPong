using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    //information on how much score each player have

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    //how many points to win
    public int goalToWin;

    // Update is called once per frame
    void Update()
    {
        //checking if one of the players has won
        if(this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            Debug.Log("Game Won");
            SceneManager.LoadScene("GameOver");
        }
        
    }

    private void FixedUpdate()
    {
        //updating the UI
        Text uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();

        Text uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();
    }

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }
    public void GoalPlayer2()
    {
        this.scorePlayer2++;
    }
}
