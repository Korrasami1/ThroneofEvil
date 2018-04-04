using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
    public bool gameOver;
    private bool restart;
    public bool winner;
    private int counterforSpawning = 0;
    private bool isSpawnOver = false;

    void Start()
    {
        gameOver = false;
        restart = false;
        winner = false;
        restartText.text = "";
        gameOverText.text = "";
        counterforSpawning = 0;
        isSpawnOver = false;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if(counterforSpawning >= 3)
        {
            isSpawnOver = true;
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.z), 0f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                counterforSpawning = counterforSpawning + 1;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitUntil(() => isSpawnOver == true);

            if (gameOver)
            {
                gameOverText.text = "GAMEOVER!";
                restartText.text = "Press 'R' to Restart";
                Restart();
                break;
            }

        }

    }
    public void GameOver()
    {
        gameOver = true;
    }
    public void Restart()
    {
        restart = true;
        isSpawnOver = false;
    }
}
