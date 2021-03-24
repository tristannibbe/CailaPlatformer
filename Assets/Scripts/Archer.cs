using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {
	public GameObject projectile;
	public Transform firepoint;
	public bool isOrc;
	private HurtPlayer arrow;
	private Animator orcAnimator;
	// Use this for initialization
	void Start () {
		if (isOrc) {
			orcAnimator = GetComponent<Animator> ();
			orcAnimator.SetBool ("isIdle", true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire(){
		GameObject arrowObject;
		arrowObject = Instantiate (projectile, new Vector3(firepoint.position.x -.2f,firepoint.position.y +.2f,firepoint.position.z), Quaternion.Euler(0,0,90)) as GameObject;
	}

	public void OnBecameVisible(){
		if (isOrc) {
			orcAnimator.SetBool ("isIdle", false);
		}
	}
}
