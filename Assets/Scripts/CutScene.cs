using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {
	public GameObject dialogueManager;
	public Text dialogueText;
	public Image fadeImage;
	public string[] dialogueLines;
	public float fadeTime;
	public AudioSource calmPlayer;
	public AudioSource battlePlayer;
	public AudioSource soundPlayer;
	public GameObject[] orcs;
	public GameObject boros;
	public GameObject door;
	public GameObject tristan;
	public GameObject dusty;
	public GameObject caila;
	public Sprite[] borosSprites;
	public Sprite[] dustySprites;
	public Sprite[] tristanSprites;
	public Sprite[] doorSprites;
	public Sprite[] cailaSprites;
	public Sprite[] orcSprites;
	public AudioClip[] music;
	public AudioClip[] sounds;
	public Transform orc1Target1;
	public Transform orc1target2;
	public Transform orc1target3;
	public Transform orc1target4;
	public Transform orc2target1;
	public Transform orc2target2;
	public float moveSpeed;
	public Transform tristanTarget;
	public Transform thirdAnimationTarget1;
	public Transform thirdAnimationTarget2;
	public Transform cailaTarget;
	public Transform offScreen;

	private int cutsceneCounter;
	private bool secondAnimationStarted;
	private float orc1Timer;
	private bool firstAnimationStarted;
	private bool fadeDone;
	private float fadeCounter;
	private int dialogueCounter;

	// Use this for initialization
	void Start () {
		fadeImage.canvasRenderer.SetAlpha (255f);
		fadeImage.CrossFadeAlpha(0f,fadeTime,false);
		dialogueCounter = 0;
		fadeCounter = 0;
		fadeDone = false;
		firstAnimationStarted = false;
		secondAnimationStarted = false;
		orc1Timer = 0;
		cutsceneCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (cutsceneCounter) {
			case 0:
				fadeCounter = fadeCounter + Time.deltaTime;
			break;
			case 1:
				orc1Timer += Time.deltaTime;
				calmPlayer.Stop ();
				battlePlayer.Play();
				if (orc1Timer < moveSpeed +.1) {
					orcs [0].transform.position = Vector2.Lerp (orcs [0].transform.position, orc1Target1.position, moveSpeed);
				}
				if(orc1Timer > moveSpeed +.1 && orc1Timer < (2*moveSpeed) +.1) {
					orcs [0].transform.position = Vector2.Lerp (orcs [0].transform.position, orc1target2.position, moveSpeed);
				}
				if (orc1Timer < (3*moveSpeed) +.1 && orc1Timer > (2*moveSpeed) +.1) {
					orcs [1].transform.position = Vector2.Lerp (orcs [1].transform.position, orc2target1.position, moveSpeed);
				}
				if (orc1Timer > (3*moveSpeed) +.1 && orc1Timer < (4*moveSpeed )+.1) {
					orcs [1].transform.position = Vector2.Lerp (orcs [1].transform.position, orc2target2.position, moveSpeed);
				}
				if (orc1Timer > (4*moveSpeed) +.1 && orc1Timer < (5*moveSpeed )+.1) {
					boros.transform.position = Vector2.Lerp (boros.transform.position, orc2target1.position, moveSpeed);
				}
				if (orc1Timer > (5 * moveSpeed) + .1) {
					cutsceneCounter = 2;
					orc1Timer = 0;
					firstAnimationStarted = true;
				}
			break;
		case 2:
			orc1Timer = orc1Timer + Time.deltaTime;
			if (orc1Timer < (5 * moveSpeed) + .1) {
				boros.GetComponent<SpriteRenderer> ().sprite = borosSprites [1];
				dialogueCounter = 4;
				orcs [2].transform.position = Vector2.Lerp (orcs [2].transform.position, orc1target3.position, .2f * moveSpeed);
			}
			if (orc1Timer > (5 * moveSpeed) + .1 && orc1Timer < (7 * moveSpeed) + .1) {
				orcs [2].transform.position = Vector2.Lerp (orcs [2].transform.position, orc1target4.position, .5f * moveSpeed);
				dusty.transform.position = Vector2.Lerp (dusty.transform.position, orc1target4.position, .5f * moveSpeed);
			}
			if (orc1Timer > (7 * moveSpeed + .1)) {
				cutsceneCounter = 3;
				secondAnimationStarted = true;
				orc1Timer = 0;
			}
			break;
		case 3:
			orc1Timer += Time.deltaTime;
			if (orc1Timer < 5 * moveSpeed) {
				dialogueCounter = 5;
				tristan.transform.eulerAngles = Vector3.Lerp (tristan.transform.eulerAngles, new Vector3 (0, 0, 0), 1f * moveSpeed);
				tristan.transform.position = Vector2.Lerp (tristan.transform.position, tristanTarget.position, .5f * moveSpeed);
				orcs [0].transform.position = Vector2.Lerp (orcs [0].transform.position, thirdAnimationTarget1.position, .25f * moveSpeed);
				orcs [1].transform.position = Vector2.Lerp (orcs [1].transform.position, thirdAnimationTarget2.position, .25f * moveSpeed);
			}
			if (orc1Timer > 5 * moveSpeed && orc1Timer < 7 * moveSpeed) {
				tristan.GetComponent<SpriteRenderer> ().sprite = tristanSprites [2];
				orcs [1].GetComponent<SpriteRenderer> ().sprite = orcSprites [1];
				dialogueCounter = 6;
			}
			if (orc1Timer > 7 * moveSpeed && orc1Timer < 9 * moveSpeed) {
				tristan.transform.localScale = new Vector3 (-1f, 1f, 1f);
				orcs [0].GetComponent<SpriteRenderer> ().sprite = orcSprites [1];
			}
			if (orc1Timer > 9 * moveSpeed) {
				dialogueCounter = 7;
				tristan.GetComponent<SpriteRenderer> ().sprite = tristanSprites [1];
				orcs [3].transform.position = Vector2.Lerp (orcs [3].transform.position, thirdAnimationTarget1.position, .25f * moveSpeed);
				orcs [4].transform.position = Vector2.Lerp (orcs [4].transform.position, thirdAnimationTarget2.position, .25f * moveSpeed);
			}
			if (orc1Timer > 15 * moveSpeed) {
				cutsceneCounter = 4;
				orc1Timer = 0;
			}
			break;
		case 4:
			orc1Timer += Time.deltaTime;	
			if (orc1Timer < 5 * moveSpeed) {
				caila.transform.eulerAngles = Vector3.Lerp (caila.transform.eulerAngles, new Vector3 (0, 0, 0), 1f * moveSpeed);
				caila.transform.position = Vector2.Lerp (caila.transform.position, cailaTarget.position, .25f * moveSpeed);
				orcs [5].transform.position = Vector2.Lerp (orcs [5].transform.position, orc1target4.position, .25f * moveSpeed);
				boros.GetComponent<SpriteRenderer> ().sprite = borosSprites [0];
				boros.transform.position = Vector2.Lerp (boros.transform.position, offScreen.position, .25f * moveSpeed);
				orcs [2].transform.position = Vector2.Lerp (orcs [2].transform.position, offScreen.position, .25f * moveSpeed);
				dusty.transform.position = Vector2.Lerp (dusty.transform.position, offScreen.position, .25f * moveSpeed);
			}
			if (orc1Timer > 5 * moveSpeed && orc1Timer < 7 * moveSpeed) {
				dialogueCounter = 8;
				caila.transform.localScale = new Vector3 (-1f, 1f, 1f);
				caila.GetComponent<SpriteRenderer> ().sprite = cailaSprites [2];
				orcs [5].GetComponent<SpriteRenderer> ().sprite = orcSprites [1];
			}
			if (orc1Timer > 7 * moveSpeed) {
				dialogueCounter = 9;
				caila.GetComponent<SpriteRenderer> ().sprite = cailaSprites [3];
				caila.transform.position = Vector2.Lerp (caila.transform.position, offScreen.position, .25f * moveSpeed);
				fadeImage.CrossFadeAlpha (255f, fadeTime * .5f, false);
			}
			if (orc1Timer > 15 * moveSpeed) {
				SceneManager.LoadScene ("Level 1.1");
			}
			break;


		}
		if (fadeCounter >= fadeTime && fadeDone == false) {
			fadeDone = true;
			calmPlayer.Play ();
			dialogueManager.SetActive (true);
		}

		if (dialogueCounter == 3 && firstAnimationStarted == false) {
			cutsceneCounter = 1;
			door.GetComponent<SpriteRenderer>().sprite = doorSprites[1];
		}

		if (dialogueCounter == 4 && secondAnimationStarted == false) {
			cutsceneCounter = 2;
			boros.GetComponent<SpriteRenderer> ().sprite = borosSprites [1];
		}

		if (fadeDone == true && Input.GetButtonDown ("Jump")) {
			dialogueCounter += 1;
		}

		dialogueText.text = dialogueLines [dialogueCounter];

	}
}
