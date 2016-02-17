using UnityEngine;
using System.Collections;
using Leap;

public class tankMovement : MonoBehaviour {

	private GameObject camera;
	private HandController controller;
	private Vector3 palmPos;
	private Vector3 palmRot;
	private Vector3 rotation;

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

		print (palmRot);
	}

	void handleTankMovement(Vector3 pos) {

		float speed = 0.5f;

		if (pos.z > 0.05)
			transform.position += transform.forward * speed;

		if (pos.z < -0.05)
			transform.position -= transform.forward * speed;
	}

	void handleTankRotation(Vector3 rot) {

		if (rot.x < -0.3f)
			transform.Rotate( rotation * rot.x );
		if (rot.x > 0.3f)
			transform.Rotate( rotation * rot.x);
	}
}
