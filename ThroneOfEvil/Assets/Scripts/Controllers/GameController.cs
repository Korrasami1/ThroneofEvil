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
	public bool winner2;
    private int counterforSpawning = 0;
	public GameObject pauseMenu;
    //private bool isSpawnOver = false;
	public float leveltimedelay = 20f;
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
        counterforSpawning = 0;
		leveltimedelay = Time.time + leveltimedelay;
		Instantiate (VoiceCommands, transform.position, Quaternion.identity);
        //isSpawnOver = false;
        StartCoroutine(SpawnWaves());
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
		if (killCounter >= WinnerCondition) {
			Winner (1);
		}else if(Time.time > leveltimedelay){
			leveltimedelay = Time.time + leveltimedelay;
			Winner (2);	
		}
		if (Input.GetButton("Cancel")/*GetKeyDown (KeyCode.Escape)*/) {
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
    public void GameOver()
    {
        gameOver = true;
    }
    public void Restart()
    {
        restart = true;
		leveltimedelay = Time.time + leveltimedelay;
    }
	public void Winner(int type)
	{
		if (type == 1) {
			winner = true;
		} else if (type == 2) {
			winner2 = true;
		}
	}
}
