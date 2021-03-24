using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Sprite open;
	public Sprite closed;
	public AudioSource checkpointNoise;

	private SpriteRenderer flagRenderer;
	private bool checkPointActive;

	// Use this for initialization
	void Start () {
		checkPointActive = false;
		checkpointNoise = GetComponent<AudioSource> ();
		flagRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player")){
			flagRenderer.sprite = open;
			if (checkPointActive == false) {
				checkpointNoise.Play ();
				checkPointActive = true;
			}
		}
	}
}
