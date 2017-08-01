using UnityEngine;
using System.Collections;

public class HiddenMovingPlaform : MonoBehaviour {
	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;

	public GameObject Block1;
	public GameObject Block2;
	public GameObject Block3;
	public GameObject Block4;
	public GameObject Block5;


	// Use this for initialization
	void Start () {
		this.currentPoint = this.points [this.pointSelection];
		Block1.GetComponent<Renderer> ().enabled = false;
		Block2.GetComponent<Renderer> ().enabled = false;
		Block3.GetComponent<Renderer> ().enabled = false;
		Block4.GetComponent<Renderer> ().enabled = false;
		Block5.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.platform.transform.position = Vector3.MoveTowards (this.platform.transform.position, this.currentPoint.position, Time.deltaTime * this.moveSpeed);
		
		if (this.platform.transform.position == this.currentPoint.position) {
			this.pointSelection = (this.pointSelection + 1) % this.points.Length;
			this.currentPoint = this.points [this.pointSelection];
		}
	}
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Nerd") {
			Block1.GetComponent<Renderer>().enabled = true;
			Block2.GetComponent<Renderer>().enabled = true;
			Block3.GetComponent<Renderer>().enabled = true;
			Block4.GetComponent<Renderer>().enabled = true;
			Block5.GetComponent<Renderer>().enabled = true;
		
		}
	}
}
