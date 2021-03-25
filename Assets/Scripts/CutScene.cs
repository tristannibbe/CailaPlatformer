using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour {
	public GameObject dialogueManager;
	public Text dialogueText;
	public string[] dialogueLines;
	public AudioSource calmPlayer;
	public AudioSource battlePlayer;

	public float moveSpeed;
	public PlayableDirector playableDirector;


	private int dialogueCounter;

	// Use this for initialization
	void Start () {
		dialogueCounter = 0;
	}

	public void PauseDirector()
    {
		playableDirector.Pause();
    }

	public void AdvanceCutSceneState()
	{
		if (playableDirector.state == PlayState.Paused)
		{
			print(dialogueCounter);
			dialogueCounter++;
			dialogueText.text = dialogueLines[dialogueCounter];
			if(dialogueCounter >= 3)
            {
				playableDirector.Play();
			}
		}
	}

	public void playBattleAudio()
    {
		calmPlayer.Stop();
		battlePlayer.Play();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
			AdvanceCutSceneState();
        }
	}
}
