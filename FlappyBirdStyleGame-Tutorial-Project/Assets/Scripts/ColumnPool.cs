using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnsPoolSize = 5;
    public GameObject columnsPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;



	// Use this for initialization
	void Start () {
        columns = new GameObject[columnsPoolSize];

        for (int i = 0; i < columnsPoolSize; i++)
        {
            columns[i] = GameObject.Instantiate(columnsPrefab, objectPoolPosition, Quaternion.identity);

        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        
        if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            // beautiful understandable intuitive code
            currentColumn++;

            if (currentColumn >= columnsPoolSize)
                currentColumn = 0;
        }
	}
}
