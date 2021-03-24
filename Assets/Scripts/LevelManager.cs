using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class LevelManager : MonoBehaviour {
	public static LevelManager levelManager;
	public float waitToRespawn;
	public PlayerController player;
	public GameObject bloodSplatter;
	public Text coinText;
	public Image heart1;
	public Image heart2;
	public Image heart3;
	public Sprite heartFull;
	public Sprite heartHalf;
	public Sprite heartEmpty;
	public int maxHealth;
	public bool invincible;
	public int startingLives;
	public Text livesText;
	public AudioSource coinPickup;
	public AudioSource lifeUp;
	public int coinCount;
	public int currrentLives;

	private bool respawning;
	private int currentHealth;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("CoinCount")){
			coinCount = PlayerPrefs.GetInt ("CoinCount");
			currrentLives = PlayerPrefs.GetInt ("PlayerLives");
		} else{
			currrentLives = startingLives;
		}
		if (levelManager == null) {
			levelManager = this;
		} else if (levelManager != this) {
			Destroy (gameObject);
		}
		currentHealth = maxHealth;
		UpdateHeartMeter ();
		coinText.text = "Coins: " + coinCount;
		livesText.text = "x" + currrentLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Respawn(){
		if (!respawning) {
			respawning = true;
			currrentLives -= 1;
			livesText.text = "x" + currrentLives;
			if (currrentLives >= 0) {
				StartCoroutine ("RespawnCo");
			} else {
				SceneManager.LoadScene ("GameOver");
			}
		}
	}

	IEnumerator RespawnCo(){
		Instantiate (bloodSplatter, player.transform.position, player.transform.rotation);
		player.gameObject.SetActive (false);
		coinCount = 0;
		coinText.text = "Coins: " + coinCount;
		yield return new WaitForSeconds (waitToRespawn);
		currentHealth = maxHealth;
		UpdateHeartMeter ();
		player.transform.position = player.respawnPos;
		player.gameObject.SetActive (true);
		respawning = false;
	}

	public void AddCoins(int Amount){
		coinCount = coinCount + Amount;
		coinPickup.Play ();
		if (coinCount >= 100) {
			coinCount -= 100;
			ChangeLives (1);
		}
		coinText.text = "Coins: " + coinCount;

	}

	public void ChangeHealth(int Amount){
		if (!invincible) {
			currentHealth = currentHealth + Amount;
			UpdateHeartMeter ();
			player.KnockBack (-Amount);
			if (currentHealth <= 0) {
				Respawn ();
			}
		}
	}

	public void ChangeLives(int amount){
		lifeUp.Play ();
		currrentLives += amount;
		livesText.text = "x" + currrentLives;
	}

	public void Addhealth(int amount){
		currentHealth += amount;
		coinPickup.Play ();
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		UpdateHeartMeter ();
	}

	public void UpdateHeartMeter(){
		switch (currentHealth) {
			case 6:
				heart1.sprite = heartFull;
				heart2.sprite = heartFull;
				heart3.sprite = heartFull;
			return;

			case 5:
				heart1.sprite = heartHalf;
				heart2.sprite = heartFull;
				heart3.sprite = heartFull;
			return;

			case 4:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartFull;
				heart3.sprite = heartFull;
			return;

			case 3:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartHalf;
				heart3.sprite = heartFull;
			return;

			case 2:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartFull;
			return;

			case 1:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartHalf;
			return;

			case 0:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
			return;

			default:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
			return;
		}
	}

}
