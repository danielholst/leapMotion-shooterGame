using UnityEngine;
using System.Collections;

/**
 * handles the health of the tank
 * reloads scene when reached zero
 **/

public class healthScript : MonoBehaviour {

	private int health;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (health <= 0) {
			print ("U dead man");
			Application.LoadLevel (0);
		}
	}

	//decreases health of tank
	public void decreaseHealth() {
		transform.position = new Vector3 (transform.position.x - 20f, transform.position.y, transform.position.z);
		health -= 10;
	}
}
