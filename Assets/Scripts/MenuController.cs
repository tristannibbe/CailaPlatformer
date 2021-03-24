using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Button yesButton;
	public Button noButton;
	public Text confirmationText;
	public int defaultLives;
	public int defaulCoins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginButton(){
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		confirmationText.gameObject.SetActive (true);
	}

	public void LoadButton(){
		SceneManager.LoadScene ("Level Select");
	}

	public void NoButton(){
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		confirmationText.gameObject.SetActive (false);
	}

	public void YesButton(){
		PlayerPrefs.SetInt ("PlayerLives", 3);
		PlayerPrefs.SetInt ("CoinCount", 0);
		PlayerPrefs.SetInt ("LevelUnlocked2", 0);
		PlayerPrefs.SetInt ("LevelUnlocked3", 0);
		PlayerPrefs.SetInt ("LevelUnlocked4", 0);
		SceneManager.LoadScene ("1st Cutscene");
	}

	public void LoadMain(){
		SceneManager.LoadScene ("Menu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
