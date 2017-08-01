using UnityEngine;
using System.Collections;

public class DestroyOnGallyDeath : MonoBehaviour {

	private GallyPatrol2 gally;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gally = FindObjectOfType<GallyPatrol2> ();
		
		if (!gally) {
			Destroy(gameObject);
		}
	}
}
