using UnityEngine;
using System.Collections;

public class SterlingProjectile : MonoBehaviour {

	public float speed;
	
	public GameObject impactEffect;
	
	public int damageToGive;
	
	public SterlingPatrol sterling;
	
	private bool right;

	private Quaternion angle;

	private float x;
	private float y;
	
	// Use this for initialization
	void Start () {
		
		sterling = FindObjectOfType<SterlingPatrol> ();
		right = !sterling.getDirection ();
		x = sterling.getX ();
		y = sterling.getY ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			transform.localScale = new Vector3 (-200f,200f,200f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-x,y);
			//GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
		} else if (!right){
			transform.localScale = new Vector3 (200f,200f,200f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-x,y);
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
