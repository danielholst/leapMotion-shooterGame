using UnityEngine;
using System.Collections;

public class onCollisionScript : MonoBehaviour {

	public GameObject explosion1;
	public GameObject explosion2;
	private GameObject player;
	private GameObject exp1;
	private GameObject exp2;
	private AudioSource source;
	private GameObject score;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Tank");
		score = GameObject.FindGameObjectWithTag ("Score");
	}
	
	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Ground")
		{
			//player.GetComponent<shootScript> ().setShooting (false);
			exp1 = Instantiate (explosion1, transform.position, transform.rotation) as GameObject;
			//Destroy (gameObject);
		}

		if(other.gameObject.tag == "Enemy")
		{
			player.GetComponent<shootScript> ().setShooting (false);
			exp1 = Instantiate (explosion1, transform.position, transform.rotation) as GameObject;
			exp2 = Instantiate (explosion2, transform.position, transform.rotation) as GameObject;
			Destroy (gameObject);
			Destroy (other.gameObject);
			score.GetComponent<scoreScript> ().increasePoints ();
		}
	}
}
