using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    //public float groundSpeed; parameter moved to game controller

    private Rigidbody2D rb2dGround;


	// Use this for initialization
	void Start () {
        rb2dGround = GetComponent<Rigidbody2D>();

        Vector2 velocityVector = new Vector2(-1, 0);
        rb2dGround.velocity = velocityVector * GameControl.instance.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance.gameOver)
        {
            rb2dGround.velocity = Vector2.zero;
        }
	}
}
