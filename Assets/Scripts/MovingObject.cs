using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
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

		if ( objToMove.transform.position.x== end.position.x) {
			currentTarget = start.position;
		}

		if ( objToMove.transform.position.x == start.position.x) {
			currentTarget = end.position;
		}
	}


}
