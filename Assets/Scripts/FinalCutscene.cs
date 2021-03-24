using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour {
	public Transform georgiePos;
	public Transform tristanPos;
	public Transform grexPos;
	public Transform tinyPos;
	public GameObject georgie;
	public GameObject tiny;
	public GameObject grex;
	public GameObject tristan;
	public float moveSpeed;

	public LevelEnd levelEnd;

	public float jumpTime;
	private float timeCounter;
	// Use this for initialization
	void Start () {
		timeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (levelEnd.dialogueCounter) {
		case 1:
			if (3*jumpTime > timeCounter) { 
				georgie.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tiny.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				grex.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tristan.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				timeCounter += Time.deltaTime;

			} else {
				georgie.transform.position = Vector3.MoveTowards (georgie.transform.position, georgiePos.position, moveSpeed * Time.deltaTime);
				tiny.transform.position = Vector3.MoveTowards (tiny.transform.position, tinyPos.position, moveSpeed * Time.deltaTime);
				grex.transform.position = Vector3.MoveTowards (grex.transform.position, grexPos.position, moveSpeed * Time.deltaTime);
				tristan.transform.position = Vector3.MoveTowards (tristan.transform.position, tristanPos.position, moveSpeed * Time.deltaTime);
			}
			break;
		case 3:
			if (2*jumpTime > timeCounter) { 
				georgie.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tiny.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				grex.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tristan.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				timeCounter += Time.deltaTime;
			} else {
				georgie.transform.position = Vector3.MoveTowards (georgie.transform.position, georgiePos.position, moveSpeed * Time.deltaTime);
				tiny.transform.position = Vector3.MoveTowards (tiny.transform.position, tinyPos.position, moveSpeed * Time.deltaTime);
				grex.transform.position = Vector3.MoveTowards (grex.transform.position, grexPos.position, moveSpeed * Time.deltaTime);
				tristan.transform.position = Vector3.MoveTowards (tristan.transform.position, tristanPos.position, moveSpeed * Time.deltaTime);
			}
			break;

		case 5:
			
			if (jumpTime > timeCounter) { 
				georgie.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tiny.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				grex.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				tristan.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
				timeCounter += Time.deltaTime;
			} else {
				georgie.transform.position = Vector3.MoveTowards (georgie.transform.position, georgiePos.position, moveSpeed * Time.deltaTime);
				tiny.transform.position = Vector3.MoveTowards (tiny.transform.position, tinyPos.position, moveSpeed * Time.deltaTime);
				grex.transform.position = Vector3.MoveTowards (grex.transform.position, grexPos.position, moveSpeed * Time.deltaTime);
				tristan.transform.position = Vector3.MoveTowards (tristan.transform.position, tristanPos.position, moveSpeed * Time.deltaTime);
			}
			break;
		case 8:
			georgie.transform.position = Vector3.MoveTowards (georgie.transform.position, georgiePos.position, moveSpeed * Time.deltaTime);
			tiny.transform.position = Vector3.MoveTowards (tiny.transform.position, tinyPos.position, moveSpeed * Time.deltaTime);
			grex.transform.position = Vector3.MoveTowards (grex.transform.position, grexPos.position, moveSpeed * Time.deltaTime);
			tristan.transform.position = Vector3.MoveTowards (tristan.transform.position, tristanPos.position, moveSpeed * Time.deltaTime);
			break;
		}
	}
}
