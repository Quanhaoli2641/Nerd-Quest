using UnityEngine;
using System.Collections;

public class JPPatrol : MonoBehaviour {

	public float moveSpeed;
	public float attackSpeed;
	private bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool atEdge;
	public Transform edgeCheck;
	
	private PlayerController player;
	
	private Animator anim;
	
	private float distanceBetween;

	//public float timer;
	//private float copyTimer;
	/*
	//Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerController>();
		anim = GetComponent<Animator>();
		//copyTimer = timer;
	}
	
	
	// Update is called once per frame
	void Update () {

		
		distanceBetween = transform.position.x - player.transform.position.x;
		
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius,whatIsWall);
		
		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius,whatIsWall);
		
		if (hittingWall || !atEdge) {
			moveRight = !moveRight;
			//anim.SetBool("Attack",false);
			//timer = copyTimer;
		}

		if (moveRight) {
			transform.localScale = new Vector3 (-100f, 100f, 100f);
		} else if (!moveRight) {
			transform.localScale = new Vector3 (100f, 100f, 100f);
		}
		
		if (distanceBetween > 0 && !moveRight) {
			anim.SetBool ("Attack", true);
			//timer -= Time.deltaTime;
			//if (timer <=0) {
			//	anim.SetBool("Attack", false);
			//	anim.SetBool("Attack2",true);
			//}
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-attackSpeed, 0f);
		}
		else if (distanceBetween < 0 && moveRight) {
			anim.SetBool ("Attack", true);
			//timer -= Time.deltaTime;
			//if (timer <=0) {
			//	anim.SetBool("Attack", false);
			//	anim.SetBool("Attack2",true);
			//}
			GetComponent<Rigidbody2D>().velocity = new Vector2 (attackSpeed, 0f);
		}
		else {
			anim.SetBool("Attack",false);
			//anim.SetBool("Attack2",false);
			if (moveRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0f);
				anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
			}
			else if (!moveRight) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, 0f);
				anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
			}
		}
		

	}*/
	void Start(){
		player = FindObjectOfType<PlayerController>();
		anim = GetComponent<Animator>();
	}
	
	void Update(){
			distanceBetween = this.transform.position.x - player.transform.position.x;

			hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
			atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
			
			if( !atEdge || hittingWall ){
				moveRight = !moveRight;
			}
			else if (distanceBetween > 0 && !moveRight ) {
				anim.SetBool ("Attack", true);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-attackSpeed, 0f);
			}
			else if (distanceBetween < 0 && moveRight) {
				anim.SetBool ("Attack", true);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (attackSpeed, 0f);
			}
			else if (distanceBetween > 0 && moveRight ) {
				anim.SetBool ("Attack", false);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, 0f);
			}
			else if (distanceBetween < 0 && !moveRight) {
				anim.SetBool ("Attack", false);
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, 0f);
			}
			
			if (moveRight) {
				this.transform.localScale = new Vector3 (-100f, 100f, 100f);
			} else if (!moveRight) {
				this.transform.localScale = new Vector3 (100f, 100f, 100f);
			}
			
			anim.SetFloat ("Speed", Mathf.Abs (this.GetComponent<Rigidbody2D> ().velocity.x));
	}
}