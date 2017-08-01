using UnityEngine;
using System.Collections;

public class TemporaryBlock : MonoBehaviour {
	private float waitTime;

	// Use this for initialization
	void Start () {
		waitTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Nerd") {
			waitTime+= Time.deltaTime;
			if(waitTime > 0.75f){
				gameObject.GetComponent<Renderer> ().enabled = false;
				//gameObject.SetActive(false);
				Destroy(gameObject);
			}
		}
	}
}
