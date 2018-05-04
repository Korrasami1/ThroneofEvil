using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
	public Transform[] spawnLocations;
	Vector3 spawn;
	public int levelNum;
	public GameObject VoiceCommands;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
	public Text gameTimerText;
    public bool gameOver;
    private bool restart;
    public bool winner;
	public bool winner2;
    private int counterforSpawning = 0;
	public GameObject pauseMenu;
	ScoreManager score;
	public float leveltimedelay = 20f;
	private float levelTime;
	private float gameTime;
	public int WinnerCondition = 3;
	private int killCounter = 0;
	public int villagerDeathCount(){
		return killCounter = killCounter + 1;
	}

    void Start()
    {
        gameOver = false;
        restart = false;
        winner = false;
		winner2 = false;
        restartText.text = "";
        gameOverText.text = "";
		gameTimerText.text = "";
        counterforSpawning = 0;
		levelTime = leveltimedelay; //for the delay
		gameTime = levelTime; //for the on screen timer
		Instantiate (VoiceCommands, transform.position, Quaternion.identity);
        //isSpawnOver = false;
		if (levelNum == 1) {
			//hazards [0].GetComponent<EnemyController> ().enabled = false;
			hazards [0].GetComponent<VillagerIdleMode> ().enabled = true;
		} /*else if (levelNum == 2) {
			hazards [0].GetComponent<EnemyController> ().enabled = true;
			hazards [0].GetComponent<VillagerIdleMode> ().enabled = false;
		}*/
        StartCoroutine(SpawnWaves());
		score = GameObject.FindWithTag ("Scoreboard").GetComponent<ScoreManager> ();
    }

    void FixedUpdate()
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
		/*if (levelNum == 2) {
			if (killCounter >= WinnerCondition) {
				Winner (1);
			} else if (Time.time > leveltimedelay) {
				leveltimedelay = Time.time + leveltimedelay;
				Winner (2);	
			}
		} else*/ 
		GUIgameTimer ();
		if (levelNum == 1) {
			if (killCounter >= WinnerCondition) {
				Winner (2);
			}
			else if (Time.time > leveltimedelay || gameTime == 0) {
				leveltimedelay = Time.time + levelTime;
				Winner (2);	
			}
		}
		if (Input.GetButton("Cancel")) {
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
		}
    }

	void GUIgameTimer(){
		gameTime -= Time.deltaTime;
		var minutes = gameTime / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = gameTime % 60;//Use the euclidean division for the seconds.
		var fraction = (gameTime * 100) % 100;

		//update the label value
		gameTimerText.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                //Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.z), 0f);
                Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, randomiseSpawnLocation(), spawnRotation);
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
			if (winner) {
				gameOverText.text = "WINNER!";
				restartText.text = "Press 'R' to Restart";
				Restart();
				break;
			}
			if (winner2) {
				SceneManager.LoadScene("Level2");
				//SceneManager.LoadScene("fristblah", LoadSceneMode.Additive);
				//SceneManager.MoveGameObjectToScene (gameObject, SceneManager.GetSceneByName("Level2"));
				break;
			}
        }

    }
	private Vector3 randomiseSpawnLocation(){
		int num = Random.Range (1, 4);
		switch (num)
		{
		case 1:
			spawn = spawnLocations [0].position;
			break;
		case 2:
			spawn = spawnLocations [1].position;
			break;
		case 3:
			spawn = spawnLocations [2].position;
			break;
		}
		return spawn;
	}
    public void GameOver()
    {
        gameOver = true;
    }
    public void Restart()
    {
        restart = true;
		leveltimedelay = Time.time + levelTime;
    }
	public void Winner(int type)
	{
		score.writeToHighscoreBoard ();
		if (type == 1) {
			winner = true;
		} else if (type == 2) {
			winner2 = true;
		}
	}
}
