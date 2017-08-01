using UnityEngine;
using System.Collections;

public class FullHealthHomework : MonoBehaviour {

	private HealthManager healthManager;

	// Use this for initialization
	void Start () {
		
		healthManager = FindObjectOfType<HealthManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<PlayerController> () == null) {
			return;
		}

		healthManager.fullHealth ();
		Destroy (gameObject);
	}


}
