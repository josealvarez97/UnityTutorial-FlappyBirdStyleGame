using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float forceMagnitude;

    private bool isDead = false;
    private Rigidbody2D rb2dReference;
    private Animator anim;

	// Use this for initialization
	void Start () {

        rb2dReference = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0)) // For the left mouse button 
            {
                //(PROBABLY NOT THE BEST WAY TO TAKE USER INPUT...) 
                //AXIS ARE BETTER IN CASE USER WANTS TO CHANGE INPUT CONFIGURATIONS...


                rb2dReference.velocity = Vector2.zero; // Shorthand writing for new Vector2(0,0). //For replicating the same behavior each time the players exerts a force (to avoid making it additive).
                Vector2 forceVector = new Vector2(0, 1);
                rb2dReference.AddForce(forceVector * forceMagnitude);

                anim.SetTrigger("Flap");
            }
        }

	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2dReference.velocity = Vector2.zero;

        isDead = true;
        anim.SetTrigger("Die");

        //Singleton pattern in action
        GameControl.instance.BirdDied(); // the beauty of an static variable...
    }



}
