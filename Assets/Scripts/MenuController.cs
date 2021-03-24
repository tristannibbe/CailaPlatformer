using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject confirmScreen;
	public int defaultLives;
	public int defaulCoins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginButton(){
		confirmScreen.SetActive(true);
	}

	public void LoadButton(){
		SceneManager.LoadScene ("Level Select");
	}

	public void NoButton(){
		confirmScreen.SetActive(false);
	}

	public void YesButton(){
		setDefaultPlayerStats();
		LockLevels();
		SceneManager.LoadScene ("1st Cutscene");
	}

	private void setDefaultPlayerStats()
    {
		PlayerPrefs.SetInt("PlayerLives", 3);
		PlayerPrefs.SetInt("CoinCount", 0);
	}

	private void LockLevels()
    {
		PlayerPrefs.SetInt("LevelUnlocked2", 0);
		PlayerPrefs.SetInt("LevelUnlocked3", 0);
		PlayerPrefs.SetInt("LevelUnlocked4", 0);
	}

	public void LoadMain(){
		SceneManager.LoadScene ("Menu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
