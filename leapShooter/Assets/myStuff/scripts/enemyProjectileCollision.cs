using UnityEngine;
using System.Collections;
using enemySpace;

/**
 * Handles the collision for enemy projectiles
**/

public class enemyProjectileCollision : MonoBehaviour {

	public GameObject explosion1;
	public GameObject explosion2;
	private GameObject player;
	private GameObject exp;
	private GameObject health;

	// Use this for initialization
	void Start () {

		health = GameObject.FindGameObjectWithTag ("Health");
		player = GameObject.FindGameObjectWithTag ("Tank");
	}

	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Ground")
		{

			//player.GetComponent<shootScript> ().setShooting (false);
			exp = Instantiate (explosion1, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);
		}

		if(other.gameObject.tag == "Tank")
		{
			//reduce health
			health.GetComponent<healthScript>().decreaseHealth();

			//create explosion
			exp = Instantiate (explosion2, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);
		}
	}
}