using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
//	private float yP;

	// Use this for initialization
	void Start () {
		//yP = platform.transform.position.y;
		this.currentPoint = this.points [this.pointSelection];

	}
	
	// Update is called once per frame
	void Update () {

		this.platform.transform.position = Vector3.MoveTowards (this.platform.transform.position, this.currentPoint.position, Time.deltaTime * this.moveSpeed);
		
		if (this.platform.transform.position == this.currentPoint.position) {
			this.pointSelection = (this.pointSelection + 1) % this.points.Length;
			this.currentPoint = this.points [this.pointSelection];
		}

		//float current = platform.transform.position.y;
		//if (current < yP || current > yP) {
		//	platform.transform.position = new Vector3(platform.transform.position.x,yP,platform.transform.position.z);
		//}

	}
}
