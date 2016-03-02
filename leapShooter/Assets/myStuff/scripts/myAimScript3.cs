﻿using UnityEngine;
using System.Collections;
using Leap;

/**
 * Script for lab
 * Create a aim and be able to shoot with the hand using the leap motion
 **/

public class myAimScript3 : MonoBehaviour {

	private HandController controller;
	public GameObject projectile;
	private Leap.Vector fingerTipPos;
	private Leap.Vector thumbTipPos;
	private Vector3 dir;
	private Vector3 pos;
	private Vector3 prevPos;
	private GameObject instantiatedProjectile;
	private bool shooting;
	private Vector3 thumbPos;
	private Vector3 prevThumbPos;
	private float projectileTimer;

	// Use this for initialization
	void Start () {

		projectileTimer = 0f;
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HandController>();
		shooting = false;
		pos = new Vector3 (3f, 3f, 3f);
		thumbPos = prevThumbPos = new Vector3 (0f, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {

		//get tip of finger position
		fingerTipPos = controller.GetFrame().Hands[0].Fingers.Frontmost.TipPosition;

		//get thumb tip position
		thumbTipPos = controller.GetFrame().Hands[0].Fingers.Leftmost.TipPosition;
	
		//convert to our world coordinates
		pos = controller.transform.TransformPoint (fingerTipPos.ToUnityScaled (false));
		thumbPos = controller.transform.TransformPoint (thumbTipPos.ToUnityScaled (false));

		//shoot projectile
		if ( checkActive(pos) && getDistance(pos, thumbPos) < 2f && (!shooting) ) {

			//instantate new projectile
			instantiatedProjectile = Instantiate (projectile, pos, new Quaternion(0f,0f,0f,0f) ) as GameObject;

			//get finger direction
			dir = controller.GetFrame ().Hands[0].Fingers.Frontmost.Direction.ToUnity ();

			shooting = true;
		}

		//to move projectile
		if (shooting) {
			instantiatedProjectile.transform.position += dir * 1f;
		}

		//destroy object when out of reach
		if (instantiatedProjectile != null && projectileTimer < 0.5f) {
			projectileTimer += Time.deltaTime;
		} else {
			Destroy (instantiatedProjectile);
			shooting = false;
			projectileTimer = 0f;
		}

		prevThumbPos = thumbPos;
		prevPos = pos;
	}

	public void setShooting(bool b) {
		shooting = b;
	}

	//check distance between thumb and finger tip to see if shooting
	public float getDistance(Vector3 a, Vector3 b) {
		return Mathf.Sqrt(Mathf.Abs(Mathf.Pow(pos.x - thumbPos.x,2) + Mathf.Pow(pos.y - thumbPos.y,2) + Mathf.Pow(pos.z - thumbPos.z,2)));
	}

	//check to see if hand is registered 
	public bool checkActive(Vector3 a) {

		if (a.x != 0.0f && a.y != -3.5f && a.z != -2.0f )
			return true;
		else
			return false;
	}
}
