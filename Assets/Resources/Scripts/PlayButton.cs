using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        //testing if the button "play" was click on it
        Debug.Log("Playgame was pressed");

        //able to move from one scene to another scene - Game Scene
        SceneManager.LoadScene("Game");
    }


}
