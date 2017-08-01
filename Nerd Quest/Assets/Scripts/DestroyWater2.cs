using UnityEngine;
using System.Collections;

public class DestroyWater2 : MonoBehaviour {

	public GameObject Water1;
	public GameObject Water2;
	public GameObject Water3;
	public GameObject Water4;
	public GameObject Water5;
	public GameObject Water6;
	public GameObject Water7;

	private GameObject currentWater;
	public Transform sliderCheck;
	public float sliderCheckRadius;
	public LayerMask whatIsSlider;
	private bool isTouching;
	private bool allDead;

	// Use this for initialization
	void Start () {
	
		currentWater = this.gameObject;
		isTouching = false;
		allDead = false;

	}

	void FixedUpdate() {
		
		if (!isTouching) {
			isTouching = Physics2D.OverlapCircle (sliderCheck.position, sliderCheckRadius, whatIsSlider);
		}
		
	}


	
	// Update is called once per frame
	void Update () {
	
		if (isTouching) {
			if (currentWater == this.gameObject) {
				currentWater.GetComponent<Renderer>().enabled = false;
				currentWater = Water1;
				
			}
			if (currentWater == Water1) {
				Water1.SetActive(false);
				currentWater = Water2;
			}
			else if (currentWater == Water2) {
				Water2.SetActive(false);
				currentWater = Water3;
			}
			else if (currentWater == Water3) {
				Water3.SetActive(false);
				currentWater = Water4;
			}
			else if (currentWater == Water4) {
				Water4.SetActive(false);
				currentWater = Water5;
			}
			else if (currentWater == Water5) {
				Water5.SetActive(false);
				currentWater = Water6;
			}
			else if (currentWater == Water6) {
				Water6.SetActive(false);
				currentWater = Water7;
			}
			if (currentWater == Water7) {
				allDead = true;
				currentWater.SetActive(false);
				currentWater = this.gameObject;
				currentWater.SetActive(false);
			}
			

			if (allDead) {
				isTouching = false;
			}
			
			
			
		}

	}

	
	public void recreate() {
		if (!isTouching && allDead) {
			currentWater.SetActive(true);
			currentWater.GetComponent<Renderer>().enabled = true;
			if (currentWater == this.gameObject) {
				Water1.SetActive(true);
				currentWater = Water1;
			}
			else if (currentWater == Water1) {
				Water2.SetActive(true);
				currentWater = Water2;
			}
			else if (currentWater == Water2) {
				Water3.SetActive(true);
				currentWater = Water3;
			}
			else if (currentWater == Water3) {
				Water4.SetActive(true);
				currentWater = Water4;
			}
			else if (currentWater == Water4) {
				Water5.SetActive(true);
				currentWater = Water5;
			}
			else if (currentWater == Water5) {
				Water6.SetActive(true);
				currentWater = Water6;
			}

			else if (currentWater == Water6) {
				Water7.SetActive(true);
				currentWater = this.gameObject;
				allDead = false;
			}

		}
	}
}
