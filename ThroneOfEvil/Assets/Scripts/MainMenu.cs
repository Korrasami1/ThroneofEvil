using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    void Update(){
    }
    public void ResumeGamePlay(){
        PauseMenuUI.SetActive (false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void PauseGamePlay(){
        PauseMenuUI.SetActive (true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene("Master"); // use this one it loades the master scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load the next scene form the curren one
    }
    public void LoadQuitScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ExitScene"); // use this one it loades the master scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); // load the next scene form the curren one
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene("Master"); // use this one it loades the master scene
        SceneManager.LoadScene("MainMenu"); // load the next scene form the curren one
    }
    public void LoadMainMenuFromQuit()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene("Master"); // use this one it loades the master scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2); // load the next scene form the curren one
    }
    //  public void LoadCredits()
    //  {
    //      SceneManager.LoadScene("Credits", LoadSceneMode.Single); //loads the credits scene
    //
    //      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); // load the credits scene, only if you are in the main menu!
    //
    //  }
    //
    //  public void ReturnToMenu()
    //  {
    //      SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //loads the main menu scene
    //
    //      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4); // load the main menu scene, only if you are in the credits scene!
    //
    //  }
    public void PauseMenuResume(){
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

