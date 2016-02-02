using UnityEngine;
using System.Collections;
using Leap;

public class myAimScript : MonoBehaviour {

	public HandController controller;
	public GameObject projectile;
	private Leap.Vector fingerTipPos;
	private Vector3 dir;
	private Vector3 pos;
	private GameObject instantiatedProjectile;
	private bool shooting;


	// Use this for initialization
	void Start () {

		shooting = false;
	}
	
	// Update is called once per frame
	void Update () {

		//get tip of finger position
		fingerTipPos = controller.GetFrame().Hands[0].Fingers.Frontmost.TipPosition;

		//convert to our world coordinates
		pos = controller.transform.TransformPoint (fingerTipPos.ToUnityScaled (false));

		//shoot projectile
		if (Input.GetKeyUp ("space") && !shooting) {

			//instantate new projectile
			instantiatedProjectile = Instantiate (projectile, pos, new Quaternion(0f,0f,0f,0f) ) as GameObject;

			//get finger direction
			dir = controller.GetFrame ().Hands[0].Fingers.Frontmost.Direction.ToUnity ();

			shooting = true;
		}

		//to move projectile
		if (shooting) {
			instantiatedProjectile.transform.position += dir;
		}

		//destroy object when out of reach
		if (instantiatedProjectile != null && instantiatedProjectile.transform.position.z > 20) {
			Destroy (instantiatedProjectile);
			shooting = false;
		}
	}
}
