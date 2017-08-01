using UnityEngine;
using System.Collections;

public class CheckSliderTouch2 : MonoBehaviour {

	private bool isTouching;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	
	public GameObject water;
	private DestroyWater2 destroyWater;

	// Use this for initialization
	void Start () {
		isTouching = false;
		destroyWater = water.GetComponent<DestroyWater2> ();
	}
	
	// Update is called once per frame
	void Update () {
		isTouching = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		if (!isTouching) {
			destroyWater.recreate();
		}
	}
	public bool getIn() {
		return isTouching;
	}

}
