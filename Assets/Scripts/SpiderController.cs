using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {
	public float moveSpeed;

	private bool canMove;
	private Rigidbody2D spiderBody;
	// Use this for initialization
	void Start () {
		spiderBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameVisible(){
		canMove = true;
		Move ();
	}

	void Move(){
		if (canMove) {
			spiderBody.velocity = new Vector3 (-moveSpeed, spiderBody.velocity.y, 0f);
		}

		Invoke ("Move", .25f);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("KillPlane")){
			gameObject.SetActive (false);
		}
	}
}
