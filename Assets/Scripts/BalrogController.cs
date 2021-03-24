using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalrogController : MonoBehaviour {
	public float fireLength;
	public float flyLength;
	public AudioSource hurt;
	public LevelEnd levelEnd;
	public Transform deathSpot;

	private Animator animator;
	private SpriteRenderer sprite;
	private float timeCounter;
	private bool hasStartedFiring;
	private bool fightStarted;
	private int stageFightCounter;
	private BossMover mover;
	private Archer archer;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		archer = GetComponent<Archer> ();	
		animator = GetComponent<Animator> ();
		stageFightCounter = 0;
		fightStarted = false;
		hasStartedFiring = false;
		mover = GetComponent<BossMover> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (stageFightCounter) {
		case 0:
			mover.enabled = false;
			break;
		case 1:
			mover.enabled = false;
			timeCounter += Time.deltaTime;
			if (hasStartedFiring == false) {
				StartFiring ();
				hasStartedFiring = true;
			}
			if (timeCounter > fireLength) {
				stageFightCounter = 2;
				timeCounter = 0;
				mover.enabled = true;
				CancelInvoke ();
			}
			break;
		case 2:
			timeCounter += Time.deltaTime;
			if (timeCounter > flyLength) {
				stageFightCounter = 1;
				timeCounter = 0;
				transform.localScale = new Vector3 (2f,2f, 1f);
				hasStartedFiring = false;
			}
			break;
		case 3:
			transform.position = Vector3.MoveTowards (transform.position, deathSpot.position, 5f *Time.deltaTime);
			break;

		}
	}

	void OnBecameVisible(){
		if (fightStarted == false) {
			fightStarted = true;
			stageFightCounter = 1;
			timeCounter = 0;
		}
	}

	void StartFiring(){
		InvokeRepeating ("fire", .5f,1.5f);
	}

	void fire(){
		archer.Fire ();
	}

	public void Damage(bool isDead){
		sprite.color = Color.red;
		hurt.Play ();
		Invoke ("Reset", .1f);
		if (isDead) {
			mover.enabled = false;
			stageFightCounter = 3;
			animator.SetBool ("isDead", true);
			levelEnd.PrepareEnd ();
		}
	}

	void Reset(){
		sprite.color = Color.white;
	}
}
