using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {
	public Text ScoreTXT;
	public Text screenPoints;
	public int TrapDoorKill, TarKill, BoulderKill, BurningBoulderKill, FireKill, LightningKill, MinionKill, ShatterKill,BurningShatterKill, IncinerationKill, Fearkill, MindControlKill, otherKill;
	public int killstreak = 0;
	public int currentScore { get; set; }
	public int TotalScores { get; set; }
	public string killType;

	// Use this for initialization
	void Start () {
		ScoreTXT.text = "";
		ScoreTXT.text = currentScore.ToString ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	private int TrapDoorKillPoints(){
		return TrapDoorKill;
	}

	private int TarKillPoints(){
		return TarKill;
	}

	private int BoulderKillPoints(){
		return BoulderKill;
	}
	private int BurningBoulderKillPoints(){
		return BurningBoulderKill;
	}
	private int FireKillPoints(){
		return TrapDoorKill;
	}

	private int LightningKillPoints(){
		return TarKill;
	}

	private int MinionKillPoints(){
		return BoulderKill;
	}
	private int ShatterKillPoints(){ //frost trap + boulder/lightning
		return ShatterKill;
	}
	private int BurningShatterKillPoints(){ //frost trap + burning boulder
		return BurningShatterKill;
	}
	private int IncinerationKillPoints(){  //oil pool + fireball
		return IncinerationKill;
	}
	private int FearKillPoints(){
		return Fearkill;
	}
	private int MindControlKillPoints(){
		return MindControlKill;
	}
	private int otherKillPoints(){
		return otherKill;
	}

	public void DealPoints(Transform other){
		screenScoreText (currentKillType(), other);
		currentScore = currentScore + currentKillType();
		TotalScores = CalculateTotalScore ();
		ScoreTXT.text = currentScore.ToString ();
		//put if statement here for a highscore scoreboard if we are doing one
	}

	private int currentKillType(){
		int points = 0;
		switch (killType)
		{
		case "Trap Door":
			points = TrapDoorKillPoints ();
			break;
		case "Tar": 
			points =  TarKillPoints (); //need to change
			break;
		case "Boulder": 
			points =  BoulderKillPoints ();
			break;
		case "Burning Boulder": 
			points =  BurningBoulderKillPoints ();
			break;
		case "Fire": 
			points =  FireKillPoints ();
			break;
		case "Lightning": 
			points =  LightningKillPoints ();
			break;
		case "Minion": 
			points =  MinionKillPoints ();
			break;
		case "Shatter": //frost trap + boulder/lightning
			points =  ShatterKillPoints ();
			break;
		case "Burning Shatter": //frost trap + burning boulder
			points =  BurningShatterKillPoints ();
			break;
		case "Incineration": //oil pool + fireball
			points =  IncinerationKillPoints ();
			break;
		case "Fear":
			points =  FearKillPoints ();
			break;
		case "MindControl":
			points =  MindControlKillPoints ();
			break;
		case "Other": 
			points =  otherKillPoints ();
			break;
		}
		Debug.Log (killstreak);
		points = MultiplyScore(points, killstreak);
		return points;
	}

	private void screenScoreText(int currentKill, Transform others){
		screenPoints.GetComponent<Text> ().text = currentKill.ToString ();
		try{
			Vector3 toCamera = Camera.main.WorldToScreenPoint(others.position);
			screenPoints.transform.position = toCamera;
			Text clonePoints = screenPoints;
			Text game = Instantiate(clonePoints, toCamera, Quaternion.identity);
			game.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
			game.transform.position = toCamera;
		}
		catch(NullReferenceException e){
			print ("healthbars off screen: "+e);
		}

	}

	public int getCurrentScore(){
		return currentScore;
	}
	public int getTotalScore(){
		return TotalScores;
	}

	private int CalculateTotalScore(){
		return TotalScores + currentScore;
	}

	public void writeToHighscoreBoard(){
		//write to tezt file or something
		PlayerPrefs.SetInt("HighScore", getCurrentScore());
	}

	int MultiplyScore(int score, int killstreak){
		if (killstreak <= 3) {
			return score;
		} else if (killstreak <= 6) {
			return score * 2;
		} else if (killstreak <= 9) {
			return score * 3;
		} else if (killstreak <= 12) {
			return score * 4;
		} else {
			return score * 5;
		}
	}
}
