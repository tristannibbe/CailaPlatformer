using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public float speed;
	public bool isAxe = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAxe == false) {
			transform.Translate (Vector3.up * Time.deltaTime * speed);
		}
		if (isAxe) {
			transform.Rotate(Vector3.forward * Time.deltaTime * 180f);
			transform.Translate (Vector3.left * Time.deltaTime * speed,Space.World);
		}
	}
}
