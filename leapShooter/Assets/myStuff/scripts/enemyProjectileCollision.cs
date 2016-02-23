using UnityEngine;
using System.Collections;
using enemySpace;

public class enemyProjectileCollision : MonoBehaviour {

	public GameObject explosion1;
	public GameObject explosion2;
	private GameObject player;
	private GameObject exp;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Tank");
	}

	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Ground")
		{
			print ("collision with ground");
			//player.GetComponent<shootScript> ().setShooting (false);
			exp = Instantiate (explosion1, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);
		}

		if(other.gameObject.tag == "Tank")
		{
			//reduce health
			exp = Instantiate (explosion2, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);
		}
	}
}