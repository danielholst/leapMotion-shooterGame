using UnityEngine;
using System.Collections;
using Leap;

public class playerRotationScript : MonoBehaviour {

	private GameObject camera;
	private HandController controller;
	private HandModel hand;
	private Quaternion handRotation;
	private Leap.Vector leapRot;
	private Vector3 rot;
	private Vector3 rotation;

	// Use this for initialization
	void Start () {

		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HandController>();
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		rotation = new Vector3 (0f, -10f, 0f);
		hand = controller.GetComponent<RiggedHand> ();
		//hand.InitHand ();
	}
	
	// Update is called once per frame
	void Update () {
		
		leapRot = controller.GetFrame ().Hands [0].PalmNormal;
		rot = leapRot.ToUnity(false);
			
		if (rot.x < -0.3f)
			camera.transform.Rotate( rotation * rot.x );
		if (rot.x > 0.3f)
			camera.transform.Rotate( rotation * rot.x);

		//print(controller.transform.TransformPoint (controller.rightPhysicsModel.GetPalmRotation ().ToUnity(false)));
		//print(hand.GetPalmRotation ()); 
		//print(controller.GetComponent<RiggedHand>().GetPalmRotation());
		print (leapRot.ToUnity(false));
	}
}
