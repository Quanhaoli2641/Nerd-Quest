using UnityEngine;
using System.Collections;

public class SusukayPatrol : MonoBehaviour {
	public float moveSpeed;
	public bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	private float distanceBetween;
	public PlayerController player;

	public LayerMask whatisSpike;
	private bool atSpike;
	public Transform spikeCheck;
	
	private Animator anim;
	public Transform firepoint;
	public GameObject projectile;

	private float timer;
	private int counter;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = FindObjectOfType<PlayerController> ();
		counter = 0;
		timer = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		distanceBetween = transform.position.x - player.transform.position.x;

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius,whatIsWall);
		
		atSpike = Physics2D.OverlapCircle (spikeCheck.position, wallCheckRadius,whatisSpike);


		if ((hittingWall || !atSpike) )
			moveRight = !moveRight;

		if (Mathf.Abs (distanceBetween) < 65 ) {
			anim.SetBool("Fire",false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			anim.SetBool ("Sword", true);
			timer += Time.deltaTime;
		}
		else if(Mathf.Abs (distanceBetween) < 300 && Mathf.Abs (distanceBetween) > 200 ){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			if(counter == 0 || timer >= 2f){
				anim.SetBool("Fire",true);
				Instantiate(projectile,firepoint.transform.position,firepoint.transform.rotation);
				timer = 0f;
				counter++;
			}
			//delayTime = 0;
			timer += Time.deltaTime;
		}
		else if (Mathf.Abs (distanceBetween) < 798 && distanceBetween < 0) {
			anim.SetBool("Fire",false);
			anim.SetBool("Sword",false);
			transform.localScale = new Vector3 (-100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			//GetComponent<Rigidbody> ().AddForce(new Vector3 (moveSpeed, 0, 0), ForceMode.VelocityChange);
			//transform.position = new Vector3(transform.position.x+100f,transform.position.y,transform.position.z);
			anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
			timer += Time.deltaTime;
		} 
		else if (Mathf.Abs (distanceBetween) < 798 && distanceBetween > 0) {
			anim.SetBool("Fire",false);
			anim.SetBool("Sword",false);
			transform.localScale = new Vector3 (100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			//GetComponent<Rigidbody> ().AddForce(new Vector3 (-moveSpeed, 0, 0), ForceMode.VelocityChange);
			//transform.position = new Vector3(transform.position.x-100f,transform.position.y,transform.position.z);
			anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
			timer += Time.deltaTime;

		} else {
			anim.SetBool("Sword",false);
			anim.SetBool("Fire",false);
			timer += Time.deltaTime;
		}

		
	}
	public bool getDirection(){
		//return moveRight;
		distanceBetween = transform.position.x - player.transform.position.x;
		return (distanceBetween > 0);
	}
	
}
