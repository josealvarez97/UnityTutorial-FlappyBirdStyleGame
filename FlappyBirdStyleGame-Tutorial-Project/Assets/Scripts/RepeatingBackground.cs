using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength; // Length along the x axis of the ground game object

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {

        // Here we'll check: Is it time to reposition?
        // Has this object scrolled out of view?
        // You may remember that the camera is looking at zero
        if (transform.position.x /*(it has been moving to the left, remember)*/ < - groundHorizontalLength /*Works because our reference is based on the origin (0,0)*/)
        {
            RepositionBackground();
        }


	}


    // Function for repositioning the background when it's time for doing so.
    private void RepositionBackground()
    {
        // How far we are going to move our ground forward when it's time to repositioning.
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0); // why to use an f after the number (https://answers.unity.com/questions/423675/why-is-there-sometimes-an-f-behinf-a-number.html)
        // One time accounts to the position of the one right to the next, and two times to the position of the one we will need later on.
        // This tricks are easily achieved thanks to the symmetry of the background.
        // working neatly has its advantages.

        // Move it twice its length to the right.
        transform.position = (Vector2) transform.position + groundOffset;

    }
}
