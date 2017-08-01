using UnityEngine;
using System.Collections;

public class DestroyWater : MonoBehaviour {
	
	public GameObject Water1;
	public GameObject Water2;
	public GameObject Water3;
	public GameObject Water4;
	public GameObject Water5;
	public GameObject Water6;
	/*
	private Transform Water1Location;
	private Transform Water2Location;
	private Transform Water3Location;
	private Transform Water4Location;
	private Transform Water5Location;
	private Transform Water6Location;
	*/
	//public GameObject copyObject;
	private GameObject currentWater;
	//private GameObject copyCurrentWater;
	public Transform sliderCheck;
	public float sliderCheckRadius;
	public LayerMask whatIsSlider;
	private bool isTouching;
	private bool allDead;
	//float delay;
	//private GameObject Water1c,Water2c,Water3c,Water4c,Water5c,Water6c;
	//public Transform otherChecker;
	//private CheckSliderTouching sliderChecker;
	
	// Use this for initialization
	void Start () {
		/*
		Water1Location = Water1.transform;
		Water2Location = Water2.transform;
		Water3Location = Water3.transform;
		Water4Location = Water4.transform;
		Water5Location = Water5.transform;
		Water6Location = Water6.transform;
		*/
		currentWater = this.gameObject;
		//copyCurrentWater = currentWater;
		isTouching = false;
		allDead = false;
		//delay = 0f;
		/*
		Water1c = Instantiate(copyObject, Water1Location.position,Water1Location.rotation) as GameObject;
		Water2c = Instantiate(copyObject, Water2Location.position,Water2Location.rotation) as GameObject;
		Water3c = Instantiate(copyObject, Water3Location.position,Water3Location.rotation) as GameObject;
		Water4c = Instantiate(copyObject, Water4Location.position,Water4Location.rotation) as GameObject;
		Water5c = Instantiate(copyObject, Water5Location.position,Water5Location.rotation) as GameObject;
		Water6c = Instantiate(copyObject, Water6Location.position,Water6Location.rotation) as GameObject;
		Water1c.SetActive (false);
		Water2c.SetActive (false);
		Water3c.SetActive (false);
		Water4c.SetActive (false);
		Water5c.SetActive (false);
		Water6c.SetActive (false);
		*/
	}
	
	
	void FixedUpdate() {
		
		if (!isTouching) {
			isTouching = Physics2D.OverlapCircle (sliderCheck.position, sliderCheckRadius, whatIsSlider);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//sliderChecker = otherChecker.GetComponent<CheckSliderTouching> ();
		if (isTouching) {
			//delay += Time.deltaTime;
			if (currentWater == this.gameObject) {
				currentWater.GetComponent<Renderer>().enabled = false;
				currentWater = Water1;
				//copyCurrentWater = Water1;
				
			}
			if (currentWater == Water1) {//copyCurrentWater == Water1) {
				//currentWater.SetActive(false);
				Water1.SetActive(false);
				currentWater = Water2;
				//copyCurrentWater = Water2;
			}
			else if (currentWater == Water2) {
				//currentWater.SetActive(false);
				Water2.SetActive(false);
				currentWater = Water3;
				//copyCurrentWater = Water3;
			}
			else if (currentWater == Water3) {
				//currentWater.SetActive(false);
				Water3.SetActive(false);
				currentWater = Water4;
				//copyCurrentWater = Water4;
			}
			else if (currentWater == Water4) {
				//currentWater.SetActive(false);
				Water4.SetActive(false);
				currentWater = Water5;
				//copyCurrentWater = Water5;
			}
			else if (currentWater == Water5) {
				//currentWater.SetActive(false);
				Water5.SetActive(false);
				currentWater = Water6;
				//copyCurrentWater = Water6;
			}
			if (currentWater == Water6) {
				allDead = true;
				//isTouching = false;
				//copyObject = this.gameObject;
				currentWater.SetActive(false);
				//copyCurrentWater = null;
				currentWater = this.gameObject;
				currentWater.SetActive(false);
				//currentWater = null;
			}
			
			//if(delay >= 1){
			//	isTouching = false;
			//}
			if (allDead) {
				isTouching = false;
			}
			
			
			
		}
		
		/*if (!isTouching) {
			if(allDead){
				currentWater = this.gameObject;
				currentWater.SetActive(true);
				Water5 = copyObject;
				Water4 = copyObject;
				Water3 = copyObject;
				Water2 = copyObject;
				Water1 = copyObject;
			}
		}*/
		
		
		
	}
	
	public void recreate() {
		if (!isTouching && allDead) {
			//currentWater = this.gameObject;
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
				currentWater = this.gameObject;
				allDead = false;
			}
			
			/*Water1c.SetActive(true);
			Water2c.SetActive(true);
			Water3c.SetActive(true);
			Water4c.SetActive(true);
			Water5c.SetActive(true);
			Water6c.SetActive(true);
	
			Water1Location = Water1.transform;
			Water2Location = Water2.transform;
			Water3Location = Water3.transform;
			Water4Location = Water4.transform;
			Water5Location = Water5.transform;
			Water6Location = Water6.transform;

			Water1c = Instantiate(copyObject, Water1Location.position,Water1Location.rotation) as GameObject;
			Water2c = Instantiate(copyObject, Water2Location.position,Water2Location.rotation) as GameObject;
			Water3c = Instantiate(copyObject, Water3Location.position,Water3Location.rotation) as GameObject;
			Water4c = Instantiate(copyObject, Water4Location.position,Water4Location.rotation) as GameObject;
			Water5c = Instantiate(copyObject, Water5Location.position,Water5Location.rotation) as GameObject;
			Water6c = Instantiate(copyObject, Water6Location.position,Water6Location.rotation) as GameObject;

			Water1 = Water1c;
			Water2 = Water2c;
			Water3 = Water3c;
			Water4 = Water4c;
			Water5 = Water5c;
			Water6 = Water6c; 

			Water1c.SetActive (false);
			Water2c.SetActive (false);
			Water3c.SetActive (false);
			Water4c.SetActive (false);
			Water5c.SetActive (false);
			Water6c.SetActive (false);
			*/
		}
	}
	
	//void OnCollisionEnter2D(Collision2D other){
	//	if (other.gameObject.tag == "Slider"){
	//		isTouching = true;
	//	}
	//}
}
