using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {
	public string[] Lines;
	public float waitTime;
	public Text talkLines;
	public Image textBox;
	public string levelToLoad;
	public PlayerController player;
	public LevelManager levelManager;
	public Image fadeImage;
	public float dialogueDelay;
	public float fadeTime;
	public GameObject dialogueManager;
	public CameraController mainCamera;
	public bool isBossLevel;
	public int levelNum;
	public Transform playerTarget;

	public int dialogueCounter;
	// Use this for initialization
	void Start () {
		fadeImage.canvasRenderer.SetAlpha (255f);
		fadeImage.CrossFadeAlpha(0f,fadeTime,false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag("Player")){
			PrepareEnd ();
		}
	}



	public void PrepareEnd(){
		player.canMove = false;
		player.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, 0f, 0f);
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		levelManager.invincible = true;
		dialogueCounter = Lines.Length;
		dialogueManager.SetActive (true);
		PlayerPrefs.SetInt ("CoinCount", levelManager.coinCount);
		PlayerPrefs.SetInt ("PlayerLives", levelManager.currrentLives);
		StartCoroutine ("EndDialogueCo");
	}

	IEnumerator EndDialogueCo(){
		if (dialogueCounter > 0) {
			talkLines.text = Lines [dialogueCounter-1];
			yield return new WaitForSeconds (dialogueDelay);
			dialogueCounter -= 1;
		} else {
			dialogueManager.SetActive (false);
			player.canMove = true;
			player.levelOver = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			mainCamera.canFollow = false;
			fadeImage.canvasRenderer.SetAlpha (0.0f);
			fadeImage.CrossFadeAlpha(255f,fadeTime,false);
			if (isBossLevel) {
				PlayerPrefs.SetInt ("LevelUnlocked" + levelNum, 1);
			}
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene (levelToLoad);
		}
		StartCoroutine ("EndDialogueCo");
	}
}
