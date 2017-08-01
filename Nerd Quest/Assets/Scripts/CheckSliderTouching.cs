using UnityEngine;
using System.Collections;

public class CheckSliderTouching : MonoBehaviour {

	private bool isTouching;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public GameObject water;
	private DestroyWater destroyWater;

	// Use this for initialization
	void Start () {
		isTouching = false;
		destroyWater = water.GetComponent<DestroyWater> ();
	}


	// Update is called once per frame
	void Update () {
		isTouching = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if (!isTouching) {
			destroyWater.recreate();
		}
	}

	/*
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Slider") {
			isTouching = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Slider") {
			isTouching = false;
		}
	}
	*/

	public bool getIn() {
		return isTouching;
	}
}
