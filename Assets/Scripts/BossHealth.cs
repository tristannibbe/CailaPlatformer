using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
	public int maxHealth;
	public int currentHealth;
	public bool isDraco;
	public bool isBalrog;

	private BalrogController balrog;
	private DracoController draco;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		if (isBalrog) {
			balrog = GetComponent<BalrogController> ();
		}

		if (isDraco) {
			draco = GetComponent<DracoController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Damage(int amount){
		currentHealth = currentHealth - amount;
		if (currentHealth <= 0) {
			if (isBalrog) {
				balrog.Damage (true);
			}
			if (isDraco) {
				draco.Damage (true);
			}
		} else {
				if (isBalrog) {
					balrog.Damage (false);
				}
				if (isDraco) {
					draco.Damage (false);
				}
			}
		}
	}
