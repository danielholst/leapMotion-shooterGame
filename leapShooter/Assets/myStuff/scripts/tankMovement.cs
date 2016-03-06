using UnityEngine;
using System.Collections;
using Leap;

/**
 * Handles the movement and rotation ofthe tank using the leap motion
 **/

public class tankMovement : MonoBehaviour {

	private GameObject camera;
	private HandController controller;
	private Vector3 palmPos;
	private Vector3 palmRot;
	private Vector3 rotation;
	public AudioSource movSound;

	// Use this for initialization
	void Start () {

		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HandController> ();
		palmPos = new Vector3 (0f, 0f, 0f);
		rotation = new Vector3 (0f, -2f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
		palmPos = controller.GetFrame ().Hands [0].PalmPosition.ToUnityScaled(false);
		palmRot = controller.GetFrame ().Hands [0].PalmNormal.ToUnity (false);

		handleTankMovement (palmPos);
		handleTankRotation (palmRot);

	}

	//moves tank based on pos of the hand
	void handleTankMovement(Vector3 pos) {

		float speed = 0.5f;

		if (pos.z > 0.05) {
			if( movSound.volume < 0.8)
				movSound.volume = movSound.volume + 0.04f;
			transform.position += transform.forward * speed;
		} else if (pos.z < -0.05) {
			if( movSound.volume < 0.7)
				movSound.volume = movSound.volume + 0.04f;
			transform.position -= transform.forward * speed;
		} 
		else if( movSound.volume > 0.3)
			movSound.volume = movSound.volume - 0.04f;
	}

	//handles the rotation of the tank based on the angle on the hand
	void handleTankRotation(Vector3 rot) {

		if (rot.x < -0.3f)
			transform.Rotate( rotation * rot.x );
		if (rot.x > 0.3f)
			transform.Rotate( rotation * rot.x);
	}
}
