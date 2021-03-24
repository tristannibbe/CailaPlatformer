using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Vector3 respawnPos;
	public LevelManager levelManager;
	public GameObject stompBox;
	public float knockBackForce;
	public float knockBackDuration;
	public AudioSource jumpSound;
	public AudioSource hurtSound;
	public bool canMove;
	public bool levelOver;
	public BoxCollider2D playerCollider;

	private float knockBackMultiplier;
	private float knockBackCounter;
	private Animator playerAnimator;
	private Rigidbody2D playerBody;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		respawnPos = transform.position;
		canMove = true;
		levelOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if (canMove == false) {
			playerBody.velocity = new Vector3 (0f,0f, 0f);
		}
		if (knockBackCounter <= 0 && canMove ) {
			if (Input.GetAxisRaw ("Horizontal") > 0f || levelOver == true ) {
				playerBody.velocity = new Vector3 (moveSpeed, playerBody.velocity.y, 0f);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
				playerBody.velocity = new Vector3 (-moveSpeed, playerBody.velocity.y, 0f);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
				;
			} else {
				playerBody.velocity = new Vector3 (0f, playerBody.velocity.y, 0f);
			}

			if (Input.GetButtonDown ("Jump") && isGrounded == true) {
				playerBody.velocity = new Vector3 (playerBody.velocity.x, jumpSpeed, 0f);
				jumpSound.Play ();
			}

		
		} else{
			knockBackCounter -= Time.deltaTime;
			playerBody.velocity = new Vector3 (-knockBackForce*knockBackMultiplier*transform.localScale.x, knockBackForce*knockBackMultiplier, 0f);
		}

		levelManager.invincible = false;

		playerAnimator.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));
		playerAnimator.SetFloat("Down", Input.GetAxisRaw ("Vertical") );
		playerAnimator.SetBool("Ground", isGrounded);

		if (playerBody.velocity.y >= 0) {
			stompBox.SetActive (false);
		} else {
			stompBox.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.CompareTag("KillPlane")){
			levelManager.Respawn ();
		}

		if(collider.CompareTag("Checkpoint")){
			respawnPos = collider.transform.position;
		}

		if(collider.CompareTag("1up")){
			levelManager.ChangeLives (1);
			Destroy (collider.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag == "Moving Platform") {
			transform.SetParent (collider.transform);
		}
	}

	void OnCollisionExit2D(Collision2D collider){
		if (collider.gameObject.tag == "Moving Platform") {
			transform.SetParent (null);
		}
	}

	public void KnockBack(int Amount){
		hurtSound.Play ();
		float num = (float)Amount;
		knockBackMultiplier = (((Mathf.Round(num / 3) + 1)) + 1)/4;
		knockBackCounter = knockBackMultiplier* knockBackDuration;
		levelManager.invincible = true;
	}





}
