using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{

    public float movementSpeed;

    private void FixedUpdate()
    {
        //in Unity - edit, project setting, you can set the vertical 1 and vertical 2 to modify the up and down (s & w)
        float vertical = Input.GetAxisRaw("Vertical2");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical) * movementSpeed;
    }
}
