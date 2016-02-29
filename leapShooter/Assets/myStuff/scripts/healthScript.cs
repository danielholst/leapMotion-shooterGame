using UnityEngine;
using System.Collections;

public class healthScript : MonoBehaviour {

	private int health;
	// Use this for initialization
	void Start () {
	
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (health == 0) {
			print ("U dead man");
			Application.LoadLevel (0);
		}
	}

	public void decreaseHealth() {

	//	print ("transform = " + transform.position + "  health = " + health);
		transform.position = new Vector3 (transform.position.x - 10f, transform.position.y, transform.position.z);
		health -= 10;
	}
}
