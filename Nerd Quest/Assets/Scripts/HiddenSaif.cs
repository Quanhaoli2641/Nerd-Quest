using UnityEngine;
using System.Collections;

public class HiddenSaif : MonoBehaviour {

	public float flashingTime;
	private float copyTime;
	private float delayTime;
	
	// Use this for initialization
	void Start () {
		delayTime = flashingTime;
		copyTime = flashingTime;
		gameObject.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//if (flashingTime > 0) {
		//flashingTime -= Time.deltaTime;
		//}
		
		//if (flashingTime < 0) {
		//decrementFlash();
		//}
		
		//if (copyTime < 0) {
		//decrementCopy();
		//}
	}
	
	public void decrementFlash() {
		gameObject.GetComponent<Renderer> ().enabled = false;
		copyTime -= Time.deltaTime;
	}
	
	public void decrementCopy() {
		gameObject.GetComponent<Renderer> ().enabled = true;
		copyTime = delayTime;
		flashingTime = delayTime;
	}
	
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Nerd") {
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		if (other.gameObject.tag == "SIR") {
			Destroy (gameObject);
		}
	}

	void OnCollsionEnter2D(Collision2D other){
		if (other.gameObject.tag == "SIR") {
			Destroy(this.gameObject);
		}
	}
}
