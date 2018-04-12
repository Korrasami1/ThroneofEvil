using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
	public GameObject VoiceCommands;
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
	public GameObject pauseMenu;
    //private bool isSpawnOver = false;

    void Start()
    {
        gameOver = false;
        restart = false;
        winner = false;
        restartText.text = "";
        gameOverText.text = "";
        counterforSpawning = 0;
		Instantiate (VoiceCommands, transform.position, Quaternion.identity);
        //isSpawnOver = false;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
		if(GetComponent<HealthController>().currentHealth <= 0)
        {
			GameOver();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
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
            //yield return new WaitUntil(() => isSpawnOver == true);
			yield return new WaitForSeconds(waveWait);

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
    }
}
