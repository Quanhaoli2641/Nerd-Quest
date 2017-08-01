using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {

	public Transform firePoint;
	public GameObject projectile;
	
	public float shotDelay;
	private float shotDelayCounter;
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		shotDelayCounter -= Time.deltaTime;
		if (shotDelayCounter <= 0) {
			shotDelayCounter = shotDelay;
			Instantiate (projectile, firePoint.position, firePoint.rotation);
		}

	}
}
