using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	private int maxHealth;
	public GameObject deathEffect;
	private bool invulnerable;
	
	// Use this for initialization
	void Start () {
		maxHealth = enemyHealth;
		invulnerable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemyHealth <= 0) {
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		
	}
	
	public void giveDamage (int damageToGive) {
		if (!invulnerable){
			enemyHealth -= damageToGive;
		}
	}
	
	public void fullHealth () {
		enemyHealth  = maxHealth;
	}
	
	public void turnInvulnerableOn() {
		invulnerable = true;
	}
	
	public void turnInvulnerableOff() {
		invulnerable = false;
	}
	
	public int returnHealth() {
		return enemyHealth;
	}
}
