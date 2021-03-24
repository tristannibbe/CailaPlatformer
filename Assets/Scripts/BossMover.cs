using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour {
	public GameObject objToMove;
	public Transform start;
	public Transform end;
	public float moveSpeed;

	private bool hasSprites;
	private bool movingTowardEnd;
	private Vector3 currentTarget;
	// Use this for initialization
	void Start () {
		currentTarget = end.position;
	}

	// Update is called once per frame
	void Update () {
		objToMove.transform.position = Vector3.MoveTowards (objToMove.transform.position, currentTarget, moveSpeed *Time.deltaTime);

		if (Mathf.Round( objToMove.transform.position.x) == Mathf.Round(end.position.x)) {
			currentTarget = start.position;
			transform.localScale = new Vector3 (-2f, 2f, 1f);
		}

		if (Mathf.Round( objToMove.transform.position.x) == Mathf.Round(start.position.x)) {
			currentTarget = end.position;
			transform.localScale = new Vector3 (2f, 2f, 1f);
		}
	}

	void OnEnable(){
		currentTarget = end.position;
	}


}