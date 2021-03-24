using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyOne;
	public Transform enemyPosOne;

	private float countDown;
	// Use this for initialization
	void Start () {
		countDown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		countDown += Time.deltaTime;
		if (countDown > 15f) {
			countDown = 0;

			Instantiate (enemyOne, enemyPosOne.position, Quaternion.identity);
		}
	}
}
