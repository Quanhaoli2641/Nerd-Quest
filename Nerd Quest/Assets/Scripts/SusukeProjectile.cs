using UnityEngine;
using System.Collections;

public class SusukeProjectile : MonoBehaviour {

	public float speed;

	public GameObject impactEffect;
	
	public int damageToGive;

	public SusukayPatrol susuke;

	private bool right;


	// Use this for initialization
	void Start () {
	
		susuke = FindObjectOfType<SusukayPatrol> ();
		right = !susuke.getDirection ();

	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			transform.localScale = new Vector3 (-200f,200f,200f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
			//GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
		} else if (!right){
			transform.localScale = new Vector3 (200f,200f,200f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			//GetComponent<Rigidbody2D> ().angularVelocity = -rotationSpeed;
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
