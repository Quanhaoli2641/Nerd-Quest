using UnityEngine;
using System.Collections;

public class SlidingBlock : MonoBehaviour {
	
	//private float initialXPosition;
	private float initialYPosition;
	public float additionalXMovement;
	public float additionalYMovement;
	public float moveSpeed;
	
//	private float combinedXPosition;
//	private float combinedYPosition;
	
	private bool movingRight;
	private bool movingUp;
	
	private bool playerOnSlider;
	private PlayerController player;

	private float positionX;
	private float positionY;
	
	// Use this for initialization
	void Start () {
		
		//initialXPosition = GetComponent<Rigidbody2D>().position.x;
		initialYPosition = GetComponent<Rigidbody2D> ().position.y;
		
		//combinedXPosition = initialXPosition + additionalXMovement;
		//combinedYPosition = initialYPosition + additionalYMovement;
		
		movingRight = true;
		movingUp = true;
		
		//player = FindObjectOfType<PlayerController> ();
		//block = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (additionalXMovement != 0f) {
			/*
			if (GetComponent<Rigidbody2D>().position.x == combinedXPosition) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
				movingRight = false;
			}

			if ((GetComponent<Rigidbody2D>().position.x == initialXPosition) && !movingRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
				movingRight = true;
			}

			if ((GetComponent<Rigidbody2D>().position.x < combinedXPosition) && movingRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			}
			else if ((GetComponent<Rigidbody2D>().position.x >= combinedXPosition) && !movingRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			}
			*/
			if(movingRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,0);

			}
			else{
				GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0);

			}
			
			//GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			transform.position = new Vector3 (transform.position.x, initialYPosition, transform.position.z);
		}
		
		if (additionalYMovement != 0f) {
			/*
			if ((GetComponent<Rigidbody2D>().position.y > combinedYPosition) && movingUp) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,moveSpeed);
			}
			if ((GetComponent<Rigidbody2D>().position.y <= combinedYPosition) && !movingUp) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-moveSpeed);
			}
			if (GetComponent<Rigidbody2D>().position.y == combinedYPosition) {
				movingUp = false;
			}
			if ((GetComponent<Rigidbody2D>().position.y == initialYPosition) && !movingUp) {
				movingUp = true;
			}
			*/
			if(movingUp){
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,moveSpeed);
			}
			else{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-moveSpeed);

			}
			
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Slider") {
			if(movingUp){
				movingUp = false;
			}
			else{
				movingUp = true;
			}
			if(movingRight){
				movingRight = false;
			}
			else{
				movingRight = true;
			}
		}
		/*
		else if (other.gameObject.tag == "Nerd") {
			playerOnSlider = true;
		}
		*/
	}


	
}
