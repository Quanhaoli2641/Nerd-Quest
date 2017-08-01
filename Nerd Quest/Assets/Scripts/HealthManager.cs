using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	
	public static int playerHealth;
	
	Text text;
	
	private LevelManager levelManager;
	
	public bool isDead;

	// Use this for initialization
	void Start () {
	
		text = GetComponent<Text> ();
		
		playerHealth = maxPlayerHealth;
		
		levelManager = FindObjectOfType<LevelManager> ();
		
		isDead = false;

	}
	
	// Update is called once per frame
	void Update () {


		if (playerHealth <= 0 && !isDead) {
			
			playerHealth = 0;
			levelManager.RespawnPlayer();
			isDead = true;
		}
		
		text.text = "" + playerHealth;

	}
	public static void HurtPlayer (int damageToGive) {
		if (playerHealth > 0) {
			playerHealth -= damageToGive;
		}
	}

	public void fullHealth () {
		playerHealth = maxPlayerHealth;
	}

	public void zeroHealth () {
		playerHealth = 0;
	}

}
