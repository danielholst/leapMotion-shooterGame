using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	private Vector3 movementVec;

	// Use this for initialization
	void Start () {
		movementVec = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

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

		transform.position = transform.position + movementVec;
	}
}
