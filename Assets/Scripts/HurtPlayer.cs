﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int Damage;
	public bool isProjectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("Player")){
			LevelManager.levelManager.ChangeHealth (-Damage);
			if (isProjectile) {
				Destroy (gameObject);
			}
		}
	}
}
