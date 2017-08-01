using UnityEngine;
using System.Collections;

public class HorizontalProjectile : MonoBehaviour {

	public float speed;
	
	public GameObject impactEffect;
	
	public float rotationSpeed;
	
	public int damageToGive;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Nerd") {

			HealthManager.HurtPlayer(damageToGive);
		}
		
		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

	}

}
