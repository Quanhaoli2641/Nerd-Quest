using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	public float xPosition;
	public float yPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Nerd") {
			other.transform.position = new Vector3 (xPosition, yPosition, other.transform.position.z);
		}
	}
}
