using UnityEngine;
using System.Collections;

public class onCollisionScript : MonoBehaviour {

	private GameObject aim;
	// Use this for initialization
	void Start () {

		aim = GameObject.FindGameObjectWithTag ("aim");
	
	}
	
	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "hitBox")
		{
			Destroy(other.gameObject);
			Destroy (gameObject);
			aim.GetComponent<myAimScript3>().setShooting (false);
		}
	}
}
