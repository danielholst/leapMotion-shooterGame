using UnityEngine;
using System.Collections;
using enemySpace;

public class shootScript : MonoBehaviour {

	private HandController controller;
	public GameObject projectile;
	private GameObject instantiatedProjectile;
	private bool shooting;
	private Vector3 shootDir;
	private Vector3 shootPos;

	// Use this for initialization
	void Start () {

		shooting = false;
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HandController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if ((controller.GetFrame ().Hands [0].GrabStrength == 1f || Input.GetKeyUp ("space")) && (!shooting)) {
			print ("shoot");
			shooting = true;
			shootDir = transform.forward;
			shootPos = new Vector3 (transform.position.x - 0.8f * shootDir.x,
									transform.position.y + 4.7f,
									transform.position.z + 13.7f * shootDir.z);
			
			//instantate new projectile
			instantiatedProjectile = Instantiate (projectile, shootPos, new Quaternion(0f,0f,0f,0f) ) as GameObject;
			shootDir = transform.forward;
		}

		//to move projectile
		if (shooting) {
			instantiatedProjectile.transform.position += shootDir * 5f;
		}
	}

	public void setShooting(bool s) {

		shooting = s;
	}
}
