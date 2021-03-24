using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public bool isLocked;
	public SpriteRenderer doorTop;
	public SpriteRenderer doorBottom;
	public Sprite doorTopClosed;
	public Sprite doorBottomClosed;
	public int levelNum;

	// Use this for initialization
	void Start () {if (levelNum > 1) {
			if (!PlayerPrefs.HasKey ("LevelUnlocked" + levelNum)) {
				isLocked = true;
			} else if (PlayerPrefs.GetInt ("LevelUnlocked" + levelNum) == 0) {
				isLocked = true;
			} else {
				isLocked = false;
			}
		} else {
			isLocked = false;
		}
		if (isLocked) {
			doorTop.sprite = doorTopClosed;
			doorBottom.sprite = doorBottomClosed;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadStartScreen(){
		SceneManager.LoadScene ("Menu");
	}

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.CompareTag ("Player") && Input.GetButtonDown ("Jump") && isLocked == false) {
			SceneManager.LoadScene ("Level " + levelNum + ".1");
		}
	}

}
