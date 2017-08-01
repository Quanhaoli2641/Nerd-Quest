using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	
	private bool doubleJumped;
	
	private Rigidbody2D myRigidBody2D;
	
	private Animator anim;
	
	private bool playerOnLadder;
	public float amountToClimb;
	
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	
	private bool atWall;
	private bool atWall2;
	private bool atWall3;
	public Transform WallCheck;
	public Transform WallCheck2;
	public Transform WallCheck3;
	public float wallRadius;

	
	// Use this for initialization
	void Start () {
		
		myRigidBody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		
	}
	
	void FixedUpdate() {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, wallRadius, whatIsGround);
		
	}
	
	// Update is called once per frame
	void Update () {

		atWall = Physics2D.OverlapCircle (WallCheck.position, groundCheckRadius,whatIsGround);
		atWall2 = Physics2D.OverlapCircle (WallCheck2.position, groundCheckRadius,whatIsGround);
		atWall3 = Physics2D.OverlapCircle (WallCheck3.position, groundCheckRadius,whatIsGround);

		if (atWall || atWall2 || atWall3) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}

		if (grounded) {
			doubleJumped = false;
		}
		
		anim.SetBool ("Grounded", grounded);
		
		if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) {
			Jump();
		}
		
		if (Input.GetKeyDown (KeyCode.UpArrow) && !doubleJumped && !grounded) {
			Jump();
			doubleJumped = true;
		}
		
		moveVelocity = 0f;
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			//myRigidBody2D.velocity = new Vector2(moveSpeed,myRigidBody2D.velocity.y);
			moveVelocity = moveSpeed;
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//myRigidBody2D.velocity = new Vector2(-moveSpeed,myRigidBody2D.velocity.y);
			moveVelocity = -moveSpeed;
		}
		
		if (knockbackCount <= 0) {
			
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			
		} else {
			
			if (knockFromRight && !atWall && !atWall2 && !atWall3) {
				//GetComponent<Rigidbody2D>().velocity = new Vector2 (knockback,0f);
				GetComponent<Rigidbody2D>().position = new Vector2 (GetComponent<Rigidbody2D>().position.x-knockback,GetComponent<Rigidbody2D>().position.y+knockback);
			}
			if (!knockFromRight && !atWall && !atWall2 && !atWall3) {
				//GetComponent<Rigidbody2D>().velocity = new Vector2 (knockback,0f);
				GetComponent<Rigidbody2D>().position = new Vector2 (GetComponent<Rigidbody2D>().position.x+knockback,GetComponent<Rigidbody2D>().position.y+knockback);
			}
			knockbackCount -=Time.deltaTime;
		}
		
		myRigidBody2D.velocity = new Vector2(moveVelocity,myRigidBody2D.velocity.y);
		
		
		if (anim.GetBool ("Punch")) {
			anim.SetBool("Punch", false);
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Punch", true);
		}
		
		if (GetComponent<Rigidbody2D>().velocity.x > 0) {
			transform.localScale = new Vector3 (-100f, 100f, 100f);
		} 
		else if (GetComponent<Rigidbody2D>().velocity.x < 0) {
			transform.localScale = new Vector3 (100f,100f,100f);
		}
		
		anim.SetBool ("OnLadder", false);
		
		if (playerOnLadder && Input.GetKey(KeyCode.UpArrow)) {
			//grounded = true;
			anim.SetBool ("OnLadder", true);
			myRigidBody2D.velocity = new Vector2 (0f, amountToClimb);
		}// else if (playerOnLadder && Input.GetKey (KeyCode.Z)) {
		//	//grounded = true;
		//	anim.SetBool ("OnLadder", true);
		//	myRigidBody2D.velocity = new Vector2 (0f, -amountToClimb);
		//}

		anim.SetFloat ("Speed", Mathf.Abs (myRigidBody2D.velocity.x));

		
	}
	
	public void Jump() 
	{
		myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x,jumpHeight);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ladder") {
			playerOnLadder = true;
			doubleJumped = false;
		}

		if (other.transform.tag == "Slider") {
			transform.parent = other.transform;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Ladder") {
			playerOnLadder = false;
		}

		if (other.transform.tag == "Slider") {
			transform.parent = null;
		}
	}


	}
