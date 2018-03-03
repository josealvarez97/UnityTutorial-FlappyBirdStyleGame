using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {

    public static GameControl instance;

    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f; // Not sure whether specifying -1.5f from the begginning actually works
    

    private int score = 0;

    // Use this for initialization
    void Awake () {
		
        if (instance == null)
        {
            // I'm needed.
            instance = this; // this means class GameControl
        }
        else if (instance != this)
        {
            // I'm not needed.
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        if (gameOver)
        {
            if (Input.GetMouseButtonDown(0)) // For the left mouse button 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }

    }


    public void BirdScored()
    {
        if (gameOver)
            return;

        score++;

        scoreText.text = "Score: " + score.ToString();
    }


    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
