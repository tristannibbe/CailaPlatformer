using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {
	public GameObject quitMenu;
	public GameObject levelSelectMenu;
	public GameObject pauseMenu;

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButtonDown("Cancel")){
			if (Time.timeScale == 1f) {
				Pause ();
			} else {
				Resume ();
			}
		}
	}

	public void Quit(){
		Time.timeScale = 1f;

		Application.Quit();
	}

	public void Resume(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}

	public void LevelSelect(){
		PlayerPrefs.SetInt ("CoinCount",LevelManager.levelManager.coinCount);
		PlayerPrefs.SetInt ("PlayerLives",LevelManager.levelManager.currrentLives);
		Time.timeScale = 1f;

		SceneManager.LoadScene ("Level Select");
	}

	public void Pause(){
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	public void QuitMenu(){
		quitMenu.SetActive (true);
	}

	public void LevelSelectMenu(){
		levelSelectMenu.SetActive (true);
	}

	public void No(){
		levelSelectMenu.SetActive (false);
		quitMenu.SetActive (false);
	}
}
