using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VariableController : MonoBehaviour {

	//for the moving of the ModMenu
	float OffsetX;
	float OffsetY;

	//public static float TestingValue;
	public Text speedText;
	public Text SpeedOfBoulderText;
	public Text spawnWaitText;
	public Text startWaitText;
	public Text waveWaitText;
	public Text enemyDamageText;
	//public Text numOfMinionText;
	public Text FireDamageText;
	public Text VilliagerdamageTraps;
	public Text VilliagerdamageDoor;
	public Text BoudlerColdownText;
	public Text BoulderFrozenDamageText;
	public Text LightningDamageText;
	public Text LightningFrozenDamageText;
	public Text ExplosionDamageText;
	//public Text exampleText;

	public EnemyController enemy;
	GameController gameController;
	public Boulder boulder;
	public VillagerDamageController villagerdamage;
	TrapController trapcontrol;

	void Start(){
		getValues ();
	}

	void getValues(){
		GameObject en = GameObject.FindWithTag ("Enemy");
		GameObject en1 = GameObject.FindWithTag ("Boulder");
		GameObject en2 = GameObject.FindWithTag ("Enemy");
		if (en != null)
		{
			enemy = en.GetComponent<EnemyController>();
		}
		if (enemy == null)
		{
			Debug.Log("Cannot find 'EnemyController' script");
		}
		if (en1 != null)
		{
			boulder = en1.GetComponent<Boulder>();
		}
		if (boulder == null)
		{
			Debug.Log("Cannot find 'Boulder script");
		}
		if (en2 != null)
		{
			villagerdamage = en2.GetComponent<VillagerDamageController>();
		}
		if (villagerdamage == null)
		{
			Debug.Log("Cannot find 'VillagerdamageController' script");
		}
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
		trapcontrol = GameObject.FindWithTag ("TrapController").GetComponent<TrapController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//exampleText.text = "the test value is: " + ExampleScript.test.ToString();
		speedText.text = "The enemy speed is: " + enemy.speed.ToString();
		startWaitText.text = "Enemystart wait is: " + gameController.startWait.ToString ();
		spawnWaitText.text = "Enemy Spawn wait is: " + gameController.spawnWait.ToString ();
		waveWaitText.text = "Enemy Wave Wait is: " + gameController.waveWait.ToString ();
		//numOfMinionText.text = "Number of minons to spawn: " + VoiceCommandController.numOfMinions.ToString ();
		SpeedOfBoulderText.text = "speed of the boulder: " + boulder.speed.ToString (); 
		FireDamageText.text = "Damage of fire is: " + villagerdamage.fireDamage.ToString (); 
		VilliagerdamageTraps.text = "Damage on villiger is: " + villagerdamage.fireFrozenDamage.ToString (); 
		VilliagerdamageDoor.text = "Damage on door is: " + villagerdamage.trapDoorDamage.ToString (); 
		BoulderFrozenDamageText.text = "BoulderFrozen Damage is: " + villagerdamage.boulderFrozenDamage.ToString (); 
		LightningDamageText.text = "LightningDamage is: " + villagerdamage.lightningDamage.ToString (); 
		LightningFrozenDamageText.text = "LightninFrozengDamage is: " + villagerdamage.lightningFrozenDamage.ToString (); 
		ExplosionDamageText.text = "ExplosiveDamage is: " + villagerdamage.explosionDamage.ToString ();


	}

	public void takeScreenShot(){
		ScreenCapture.CaptureScreenshot ("ScreenShot.PNG");
	}

	//Make the ModeMenu draggable on the screen.
	public void BeginDrag(){
		OffsetX = transform.position.x - Input.mousePosition.x;
		OffsetY = transform.position.y - Input.mousePosition.y;

	}

	//Make the ModeMenu draggable on the screen.
	public void OnDrag(){
		transform.position = new Vector3 (OffsetX + Input.mousePosition.x, OffsetY + Input.mousePosition.y);

	}


//	//updates the variable from the inputfield
//	public void Text_Example(string newValueExample){
//
//		float tempExample = float.Parse(newValueExample);
//		ExampleScript.test = tempExample;
//		//Debug.Log("value update" + newValueSpeed);
//		Debug.Log("THe value of test is:  " + ExampleScript.Test);
//
//	}


//----------------------------------------------------------------------------------
	//this chanches the values of the int/float whit the help of textInputfield it (it dosent work as good as buttons)
//-----------------------------------------------------------------------------------

	//updates the variable from the inputfield
	public void Text_EnemySpeed(string newValueSpeed){

	  float tempSpeed = float.Parse(newValueSpeed);
	  enemy.speed = tempSpeed;
	  //Debug.Log("value update" + newValueSpeed);
	  Debug.Log("speed value of enemyes updated to:  " + enemy.speed);
	
	}
		

//--------------------------------------------------------------------------------------
//this changes the values of the int/float whit the help of buttons
//--------------------------------------------------------------------------------------
	public void onClickButtonHigher(){
		if(!(trapcontrol.BoulderCooldownSpeed >= 10)){
			trapcontrol.BoulderCooldownSpeed++;
			//BoudlerColdownText.text = "couldown on boulder is: " + TrapController.BoulderCooldownSpeed.ToString ();
			}
		}
	public void onClickButtonLower(){
		if(!(trapcontrol.BoulderCooldownSpeed <= 0)){
			trapcontrol.BoulderCooldownSpeed--;
			//BoudlerColdownText.text = "couldown on boulder is: " + TrapController.BoulderCooldownSpeed.ToString ();
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickSpeedButtonHigher(){
		if(!(enemy.speed >= 10)){
			enemy.speed++;
			//BoudlerColdownText.text = "couldown on boulder is: " + TrapController.BoulderCooldownSpeed.ToString ();
		}
	}
	public void onClickSpeedButtonLower(){
		if(!(enemy.speed <= 0)){
			enemy.speed--;
			//BoudlerColdownText.text = "couldown on boulder is: " + TrapController.BoulderCooldownSpeed.ToString ();
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickFireDamageHigher(){
		if(!(villagerdamage.fireDamage >= 100)){
			villagerdamage.fireDamage++;
		}
	}
	public void onClickFireDamageLower(){
		if(!(villagerdamage.fireDamage <= 0)){
			villagerdamage.fireDamage--;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickSpawnWaitHigher(){
		if(!(gameController.spawnWait >= 10)){
			gameController.spawnWait += 0.1f;

		}
	}
	public void onClickSpawnWaitLower(){
		if(!(gameController.spawnWait <= 0)){
			gameController.spawnWait -= 0.1f;
		}
	}
	public void onClickSpawnWaitHigherOne(){
		if(!(gameController.spawnWait >= 10)){
			gameController.spawnWait += 1;

		}
	}
	public void onClickSpawntWaitLowerOne(){
		if(!(gameController.spawnWait <= 0)){
			gameController.spawnWait -= 1;
		}
	}

	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickStartWaitHigher(){
		if(!(gameController.startWait >= 10)){
			gameController.startWait += 0.1f;

		}
	}
	public void onClickStartWaitLower(){
		if(!(gameController.startWait <= 0)){
			gameController.startWait -= 0.1f;
			Debug.Log("the value is now:  " + gameController.startWait);
		}
	}

	public void onClickStartWaitHigherOne(){
		if(!(gameController.startWait >= 10)){
			gameController.startWait += 1;

		}
	}
	public void onClickStartWaitLowerOne(){
		if(!(gameController.startWait <= 0)){
			gameController.startWait -= 1;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickWaveWaitHigher(){
		if(!(gameController.waveWait >= 10)){
			gameController.waveWait += 0.1f;

		}
	}
	public void onClickWaveWaitLower(){
		if(!(gameController.waveWait <= 0)){
			gameController.waveWait -= 0.1f;
		}
	}

	public void onClickWaveWaitHigherOne(){
		if(!(gameController.waveWait >= 10)){
			gameController.waveWait += 1;

		}
	}
	public void onClickWaveWaitLowerOne(){
		if(!(gameController.waveWait <= 0)){
			gameController.waveWait -= 1;
		}
	}


	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickVillageDamageHigher(){
		if(!(villagerdamage.fireFrozenDamage >= 10000)){
			villagerdamage.fireFrozenDamage += 10;
		}
	}
	public void onClickVillageDamageLower(){
		if(!(villagerdamage.fireFrozenDamage <= 0)){
			villagerdamage.fireFrozenDamage -= 10;
		}
	}
	public void onClickVillageDamageHigherOne(){
		if(!(villagerdamage.fireFrozenDamage >= 10000)){
			villagerdamage.fireFrozenDamage += 1;
		}
	}
	public void onClickVillageDamageLowerOne(){
		if(!(villagerdamage.fireFrozenDamage <= 0)){
			villagerdamage.fireFrozenDamage -= 1;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickVillageDamageDoorHigher(){
		if(!(villagerdamage.trapDoorDamage >= 10000)){
			villagerdamage.trapDoorDamage += 10;
		}
	}
	public void onClickVillageDamageDoorLower(){
		if(!(villagerdamage.trapDoorDamage <= 0)){
			villagerdamage.trapDoorDamage -= 10;
		}
	}
	public void onClickVillageDamageDoorHigherOne(){
		if(!(villagerdamage.trapDoorDamage >= 10000)){
			villagerdamage.trapDoorDamage += 1;
		}
	}
	public void onClickVillageDamageDoorLowerOne(){
		if(!(villagerdamage.trapDoorDamage <= 0)){
			villagerdamage.trapDoorDamage -= 1;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickboulderFrozenDamageHigher(){
		if(!(villagerdamage.boulderFrozenDamage >= 10000)){
			villagerdamage.boulderFrozenDamage += 100;
		}
	}
	public void onClickboulderFrozenDamageLower(){
		if(!(villagerdamage.boulderFrozenDamage <= 0)){
			villagerdamage.boulderFrozenDamage -= 100;
		}
	}
	public void onClickboulderFrozenDamageHigherOne(){
		if(!(villagerdamage.boulderFrozenDamage>= 10000)){
			villagerdamage.boulderFrozenDamage += 10;
		}
	}
	public void onClickboulderFrozenDamageLowerOne(){
		if(!(villagerdamage.boulderFrozenDamage <= 0)){
			villagerdamage.boulderFrozenDamage -= 10;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickLightningDamageHigher(){
		if(!(villagerdamage.lightningDamage >= 10000)){
			villagerdamage.lightningDamage += 100;
		}
	}
	public void onClickLightningDamageLower(){
		if(!(villagerdamage.lightningDamage <= 0)){
			villagerdamage.lightningDamage -= 100;
		}
	}
	public void onClickLightningDamageHigherOne(){
		if(!(villagerdamage.lightningDamage>= 10000)){
			villagerdamage.lightningDamage += 10;
		}
	}
	public void onClickLightningDamageLowerOne(){
		if(!(villagerdamage.lightningDamage <= 0)){
			villagerdamage.lightningDamage -= 10;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickLightningFrozenDamageHigher(){
		if(!(villagerdamage.lightningFrozenDamage >= 10000)){
			villagerdamage.lightningFrozenDamage += 100;
		}
	}
	public void onClickLightningFrozenDamageLower(){
		if(!(villagerdamage.lightningFrozenDamage <= 0)){
			villagerdamage.lightningFrozenDamage -= 100;
		}
	}
	public void onClickLightningFrozenDamageHigherOne(){
		if(!(villagerdamage.lightningFrozenDamage >= 10000)){
			villagerdamage.lightningFrozenDamage += 10;
		}
	}
	public void onClickLightningFrozenDamageLowerOne(){
		if(!(villagerdamage.lightningFrozenDamage <= 0)){
			villagerdamage.lightningFrozenDamage -= 10;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickExplosionDamageHigher(){
		if(!(villagerdamage.explosionDamage >= 10000)){
			villagerdamage.explosionDamage += 100;
		}
	}
	public void onClickExplosionDamageLower(){
		if(!(villagerdamage.explosionDamage <= 0)){
			villagerdamage.explosionDamage -= 100;
		}
	}
	public void onClickExplosionDamageHigherOne(){
		if(!(villagerdamage.explosionDamage >= 10000)){
			villagerdamage.explosionDamage += 10;
		}
	}
	public void onClickExplosionDamageLowerOne(){
		if(!(villagerdamage.explosionDamage <= 0)){
			villagerdamage.explosionDamage -= 10;
		}
	}
	//--------------------------------------------------------------------------------------
	//--------------------------------------------------------------------------------------
	public void onClickSpeedOfBoulderHigher(){
		if(!(boulder.speed >= 20)){
			boulder.speed += 0.1f;
		}
	}
	public void onClickSpeedOfBoulderLower(){
		if(!(boulder.speed <= 0)){
			boulder.speed -= 0.1f;
		}
	}
	public void onClickSpeedOfBoulderHigherOne(){
		if(!(boulder.speed >= 20)){
			boulder.speed += 1;
		}
	}
	public void onClickSpeedOfBoulderLowerOne(){
		if(!(boulder.speed <= 0)){
			boulder.speed -= 1;
		}
	}
	//--------------------------------------------------------------------------------------

}



//	public void OnClickApply(){
////		Apply = true;
//		Debug.Log("applyed");
//
//	}




