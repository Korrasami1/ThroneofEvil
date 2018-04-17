using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text ScoreTXT;
	public int TrapDoorKill, TarKill, BoulderKill, FireKill, LightningKill, MinionKill, ShatterKill, IncinerationKill, Fearkill, otherKill;
	public int currentScore { get; set; }
	public int TotalScores { get; set; }
	public string killType;

	// Use this for initialization
	void Start () {
		ScoreTXT.text = "";
		ScoreTXT.text = currentScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
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
	private int IncinerationKillPoints(){  //oil pool + fireball
		return IncinerationKill;
	}
	private int FearKillPoints(){  //oil pool + fireball
		return Fearkill;
	}
	private int otherKillPoints(){
		return otherKill;
	}

	public void DealPoints(){
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
		case "Incineration": //oil pool + fireball
			points =  IncinerationKillPoints ();
			break;
		case "Fear": //oil pool + fireball
			points =  FearKillPoints ();
			break;
		case "Other": 
			points =  otherKillPoints ();
			break;
		}
		return points;
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

	private void writeToHighscoreBoard(){
		//write to tezt file or something
	}

}
