using UnityEngine;
using System.Collections;

public class GallyPatrol : MonoBehaviour {

	
	public float moveSpeed;
	private bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private float distanceBetween;
	private PlayerController player;
	
	private Animator anim;
	public Transform firepoint;
	public GameObject snake;
	
	public float pianoRadius;
	public float snakeRadius;
	public float snakeAnimTime;
	private float copyTime;
	public bool action;
	private float timer;
	private int counter;
	
	//private EnemyHealthManager EHM;
	//private bool firstDeath;
	
	//Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator>();
		player = FindObjectOfType<PlayerController>();
		copyTime = snakeAnimTime;
		//action = false;
		//firstDeath = false;
		//EHM = GetComponent<EnemyHealthManager>();
		
	}
	
	
	// Update is called once per frame
	void Update () {

		distanceBetween = transform.position.x - player.transform.position.x;
		

		//hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius,whatIsWall);
		
		//if (hittingWall) {
		//	moveRight = !moveRight;
		//}
		if ((Mathf.Abs(distanceBetween) <= snakeRadius)) {
			//action = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,0f);
			anim.SetBool("Piano", false);
			anim.SetBool("Snake", true);
			snakeAnimTime -= Time.deltaTime;
			if (snakeAnimTime <= 0){
				Instantiate(snake, firepoint.transform.position, firepoint.transform.rotation);
				snakeAnimTime = copyTime;
				//	action = false;
			}
		}
		else if (Mathf.Abs(distanceBetween) <= pianoRadius) {
			//action = true;
			//EHM.turnInvulnerableOn();
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,0f);
			anim.SetBool("Snake", false);
			anim.SetBool("Piano", true);
		//	action = false;
			//EHM.turnInvulnerableOff();
		}

	}
}
		/*
		else if (Mathf.Abs(distanceBetween) <= snakeRadius && moveRight){
			anim.SetBool("Piano", false);
			anim.SetBool("Snake",false);
			transform.localScale = new Vector3 (-100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
		}
		
	}*/
		/*
		else if (Mathf.Abs(distanceBetween) >= snakeRadius && !moveRight) {
			anim.SetBool("Piano", false);
			anim.SetBool("Snake",false);
			transform.localScale = new Vector3 (100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
		}
		
		else if ((Mathf.Abs(distanceBetween) <= snakeRadius)) {
			//action = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,0f);
			anim.SetBool("Piano", false);
			anim.SetBool("Snake", true);
			snakeAnimTime -= Time.deltaTime;
			if (snakeAnimTime <= 0){
				Instantiate(snake, firepoint.transform.position, firepoint.transform.rotation);
				snakeAnimTime = copyTime;
				//	action = false;
			}
			
		}
		else if (distanceBetween > 0) {
			//moveRight = false;
			anim.SetBool("Piano", false);
			anim.SetBool("Snake",false);
			transform.localScale = new Vector3 (100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0);

		}
		else if (distanceBetween < 0) {
			//moveRight = true;
			anim.SetBool("Piano", false);
			anim.SetBool("Snake",false);
			transform.localScale = new Vector3 (-100f, 100f, 100f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, 0);
		}
		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));
//		if (EHM.returnHealth() <= 0 && !firstDeath) {
//			EHM.turnInvulnerableOn();
//			anim.SetBool("Revive",true);
//			EHM.fullHealth();
//			anim.SetBool("Revive", false);
//			EHM.turnInvulnerableOff();
//			firstDeath = true;
//		}

	}
		
		
	}
	public bool getDirection(){
		return moveRight;
		//distanceBetween = transform.position.x - player.transform.position.x;
		//return (distanceBetween > 0);
	}

}
*/