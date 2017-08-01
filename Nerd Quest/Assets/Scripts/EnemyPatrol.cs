using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool atEdge;
	public Transform edgeCheck;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius,whatIsWall);

		atEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius,whatIsWall);

		if (hittingWall || !atEdge)
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3 (-200f, 200f, 200f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (200f,200f,200f);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

	}
}
