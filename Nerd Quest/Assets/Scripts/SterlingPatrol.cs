using UnityEngine;
using System.Collections;

public class SterlingPatrol : MonoBehaviour {

	public float moveSpeed;

	private PlayerController player;

	private float xDistance;
	private float yDistance;

	private Animator anim;

	public Transform edgeCheck;
	public float edgeCheckRadius;
	public LayerMask whatIsGround;

	public Transform wallCheck;

	private bool atEdge;
	private bool atWall;
	
	private float counter;

	private Rigidbody2D myRigidbody;

	private bool moveRight;

	private double timer;
	private double timer2;

	private bool check;

	public GameObject spit;
	public Transform firepoint;
	

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		counter = 0;
		moveRight = true;
		timer = 1.5;
		timer2 = 1;
	
	}
	
	// Update is called once per frame
	void Update () {

		
		xDistance = transform.position.x - player.transform.position.x;
		yDistance = player.transform.position.y - transform.position.y;

		atEdge = Physics2D.OverlapCircle (edgeCheck.position, edgeCheckRadius, whatIsGround);
		atWall = Physics2D.OverlapCircle (wallCheck.position, edgeCheckRadius, whatIsGround);

		if (!atEdge || atWall) {
			moveRight = !moveRight;
		}

		if (moveRight) {
			transform.localScale = new Vector3 (-100f, 100f, 100f);
		} else if (!moveRight) {
			transform.localScale = new Vector3 (100f, 100f, 100f);
		}


		if(yDistance > 100f && ((transform.position.x>player.transform.position.x && !moveRight) || (transform.position.x<player.transform.position.x && moveRight))) {
		    GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,0f);
			anim.SetBool("Spit", true);
			anim.SetBool("Stomp", false);
			if (timer2 == 1f) {
				Instantiate(spit,firepoint.position,firepoint.rotation);
				timer2 -= Time.deltaTime;
			}
			else if (timer2 < 1f && timer2 > 0f) {
				timer2 -= Time.deltaTime;
			}
			else if (timer2 <= 0f) {
				timer2 = 1f;
			}
			counter = 0f;
		}
		else if (yDistance<100f && counter >= 4f) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
			anim.SetBool ("Stomp", true);
			anim.SetBool("Spit",false);
			timer-=Time.deltaTime;
			if (timer <= 0) {
				timer = 1.5f;
				counter = 0f;
			}

		} else if ((yDistance<100 && timer <= 0f) || counter <= 4f) {
			anim.SetBool("Stomp", false);
			anim.SetBool("Spit", false);
			if (moveRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
			} else if (!moveRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, myRigidbody.velocity.y);
			}
			counter+=Time.deltaTime;
		} 
		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
	}

	public bool getDirection(){
		//return moveRight;
		xDistance = transform.position.x - player.transform.position.x;
		return (xDistance > 0);
	}

	public float getX() {
		return xDistance;
	}

	public float getY() {
		return yDistance;
	}
	
}
