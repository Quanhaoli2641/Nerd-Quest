using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	private Rigidbody2D fish;
	public float moveSpeed;
	private bool up;

	public GameObject impactEffect;
	public int damageToGive;

	public float height;


	// Use this for initialization
	void Start () {
	
		fish = GetComponent<Rigidbody2D> ();
		up = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (fish.position.y >= height) {
			up = false;
		}

		if (fish.position.y <= height && up) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, moveSpeed);
		} else if(!up) {
			transform.localScale = new Vector3 (-100f, -100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, -moveSpeed);

		}

		//if (fish.position.y <= 1250f) {
		//	Instantiate (impactEffect, transform.position, transform.rotation);
		//	Destroy (gameObject);
		//}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "FishCannon") {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Nerd") {

			HealthManager.HurtPlayer(damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

	}
}
