using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour {
	public GameObject bloodSplatter;
	public float bounceForce;
	public GameObject[] enemyDrops;
	public LevelManager levelManager;

	private BossHealth draco;
	private bool bossAdded;
	private GiveHealth dropitem;
	private GameObject drop;
	private int spawnInt;
	private Transform spawnTransform;
	private Rigidbody2D playerBody;
	// Use this for initialization
	void Start () {
		playerBody = GetComponentInParent<Rigidbody2D> ();
		bossAdded = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.CompareTag ("Enemy")) {

			collider.gameObject.SetActive (false);

			Instantiate (bloodSplatter, collider.transform.position, collider.transform.rotation);
			playerBody.velocity = new Vector3 (playerBody.velocity.x, bounceForce, 0f);
			spawnTransform = collider.transform;
			SpawnLoot ();
		}
		if (collider.CompareTag ("Boss")) {
			if (bossAdded == false) {
				draco = collider.GetComponent<BossHealth> ();
				bossAdded = true;
			}
			draco.Damage (1);
			playerBody.velocity = new Vector3 (playerBody.velocity.x, bounceForce, 0f);
		}



	}

	void SpawnLoot(){
		spawnInt = Random.Range (1, 101);
		if (spawnInt <= 50) {
			drop = Instantiate (enemyDrops [0], spawnTransform.transform.position, spawnTransform.transform.rotation);
		}
		if (spawnInt > 50 && spawnInt <= 75) {
			Instantiate (enemyDrops [1], spawnTransform.transform.position, spawnTransform.transform.rotation);
		}
		if (spawnInt > 75 && spawnInt <= 90) {
			Instantiate (enemyDrops [2], spawnTransform.transform.position, spawnTransform.transform.rotation);
		}
		if (spawnInt > 90 && spawnInt <= 97) {
			Instantiate (enemyDrops [3], spawnTransform.transform.position, spawnTransform.transform.rotation);
		}
		if (spawnInt > 97 && spawnInt <= 100) {
			Instantiate (enemyDrops [4], spawnTransform.transform.position, spawnTransform.transform.rotation);
		}
	}
		
}
