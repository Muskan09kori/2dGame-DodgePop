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

    void Update()
    {
        // Start game when player taps screen
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
            tapText.SetActive(false);
        }

        // Detect Android back button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnpos = spawnPoint.position;

        spawnpos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnpos, Quaternion.identity);

        score++;

        Score.text = score.ToString();
    }

    private void ExitGame()
    {
        Debug.Log("Back button pressed. Exiting game.");
        Application.Quit();
    }
}
