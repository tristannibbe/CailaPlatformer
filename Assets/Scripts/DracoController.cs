using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracoController : MonoBehaviour {

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	public float jumpSpeed;
	public float moveSpeed;
	public int jumpLength;
	public Sprite[] sprites;
	public float jumpTimeLength;
	public float throwTimeLength;
	public LevelEnd levelEnd;

	private BossMover mover;
	private Rigidbody2D dracoBody;
	private bool isGrounded;
	private int stageFightCounter;
	private AudioSource hurt;
	private SpriteRenderer sprite;
	private Archer archer;
	private bool fightStarted;
	private float stageCounter;

	// Use this for initialization
	void Start () {
		mover = GetComponent<BossMover> ();
		dracoBody = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		archer = GetComponent<Archer> ();
		hurt = GetComponent<AudioSource> ();
		fightStarted = false;
		stageFightCounter = 0;
		stageCounter = 0;
		mover.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (stageFightCounter) {
		case 0:
			break;

		case 1:
			stageCounter += Time.deltaTime;
			if (stageCounter > throwTimeLength){
				stageFightCounter = 2;
				stageCounter = 0;
				CancelInvoke ();
				InvokeRepeating ("Jump", .25f, 1.5f);
				}
			break;

		case 2:
			isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
			mover.enabled = true;
			stageCounter += Time.deltaTime;
			if (stageCounter > jumpTimeLength) {
				stageFightCounter = 3;
			}
			if (!isGrounded) {
				sprite.sprite = sprites [1];
			} else {
				sprite.sprite = sprites [0];
			}
			break;
		case 3:
			StartThrowing ();
			break;
		case 4:
			mover.enabled = false;
			CancelInvoke ();
		
			break;
		}
	}

	public void Damage(bool isDead){
		sprite.color = Color.red;
		hurt.Play ();
		Invoke ("Reset", .1f);
		if (isDead) {
			sprite.sprite = sprites [2];
			stageFightCounter = 4;
			levelEnd.PrepareEnd ();
		}
	}

	public void Reset(){
		sprite.color = Color.white;
			sprite.sprite = sprites [0];
	}

	public void OnBecameVisible( ){
		if( fightStarted == false){
			StartThrowing ();
		}
	}

	public void fire(){
		sprite.sprite = sprites [1];
		archer.Fire ();
		Invoke ("Reset", .15f);
	}

	public void StageOne(){
		CancelInvoke ();
		InvokeRepeating ("fire", .5f,1.5f);

	}

	void Jump ()
	{
		dracoBody.velocity = new Vector3 (dracoBody.velocity.x, jumpSpeed, 0f);
	}

	void StartThrowing(){
		mover.enabled = false;
		stageFightCounter =  1;
		fightStarted = true;
		StageOne ();
		stageCounter = 0;
		transform.localScale = new Vector3 (2f, 2f, 1f);
		sprite.sprite = sprites [0];
	}


}
