using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
	public float lifeTime;

	private float timeLeft;
	// Use this for initialization
	void Start () {
		timeLeft = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = timeLeft - Time.deltaTime;
		if (timeLeft <= 0f) {
			Destroy (gameObject);
		}
	}
}
