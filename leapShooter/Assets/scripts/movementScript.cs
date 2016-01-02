using UnityEngine;
using System.Collections;

/*
 * Handles player movement
 */

public class movementScript : MonoBehaviour {

	private Vector3 movementVec;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		movementVec = new Vector3(0f, 0f, 0f);
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		//movement
		movementVec.Set (0f, 0f, 0f);

		if (Input.GetKey (KeyCode.A)) {
			movementVec.Set (movementVec.x - 0.1f, movementVec.y, movementVec.z);
		}
		if(Input.GetKey(KeyCode.W)) {
			movementVec.Set (movementVec.x, movementVec.y, movementVec.z + 0.1f);
		}
		if(Input.GetKey(KeyCode.S)) {
			movementVec.Set (movementVec.x, movementVec.y, movementVec.z - 0.1f);
		}
		if(Input.GetKey(KeyCode.D)) {
			movementVec.Set (movementVec.x + 0.1f, movementVec.y, movementVec.z);
		}

		//jump
		if (Input.GetKey (KeyCode.Space) && (transform.position.y <= 1f)) {
			rigidBody.AddForce (Vector3.up*40f);
		}

		transform.position = transform.position + movementVec;
	}
}
