using UnityEngine;
using System.Collections;

public class GallyPatrol2 : MonoBehaviour {

	public float snakeAnimTime;

	public Transform firepoint;
	public GameObject snake;
	private float copyTime;
	private float timer;
	//private float secTimer;

	private Animator anim;

	// Use this for initialization
	void Start () {
		timer = 0f;
		copyTime = snakeAnimTime;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 12f){ //&& secTimer <= 6f) {
			anim.SetBool ("Piano", false);
			//anim.SetBool ("SecPiano", false);
			anim.SetBool ("Snake", true);
			snakeAnimTime -= Time.deltaTime;
			if (snakeAnimTime <= 0) {
				Instantiate (snake, firepoint.transform.position, firepoint.transform.rotation);
				snakeAnimTime = copyTime;
			}
			timer += Time.deltaTime;
			//secTimer += Time.deltaTime;
		} else if (timer > 12f){ //&& secTimer < 6f) {
			anim.SetBool ("Snake", false);
			//anim.SetBool ("SecSnake", false);
			anim.SetBool ("Piano", true);
			timer = 0f;
		} //else if (secTimer > 6f && timer < 10f) {
		//	anim.SetBool ("Snake", false);
		//	anim.SetBool ("SecPiano", true);
		//	anim.SetBool ("Piano", false);
		//	secTimer = 0f;
		else {
			anim.SetBool("Piano", false);
			//anim.SetBool("SecPiano", false);
			anim.SetBool("Snake", false);
		}
	}
}
