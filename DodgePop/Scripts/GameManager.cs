using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate; 

    bool gameStarted = false;


    public GameObject tapText;
    public TextMeshProUGUI Score;

    int score = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            
            gameStarted = true;
            tapText.SetActive(false);
        }
    }


    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }
    // Start is called before the first frame update
    
    
    private void SpawnBlock()
    {
        Vector3 spawnpos = spawnPoint.position;

        spawnpos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnpos , Quaternion.identity);

        score++;

        Score.text = score.ToString();

    }


}
