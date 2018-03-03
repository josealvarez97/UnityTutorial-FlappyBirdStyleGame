using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    // KEY DIFFERENCE FROM ON COLLISION ENTER 2D. 
    // We want to check whether we passed through a trigger, not collided with a solid object.
    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.GetComponent<Bird>() != null)
        {
            //Whatever passes through the trigger, we're gonna check to see if it's a bird.
            // If it does have a bird component attached to it...
            GameControl.instance.BirdScored();

            // What is confusing is how the bird becomes a component of the... ohhhh yea
            // no no no yes. The other is the bird game object, which should have a bird object attached to it necessarily.
            // But I wonder if it actually referes to Class Bird of the Game Object itself...
        }
        
    }
}
