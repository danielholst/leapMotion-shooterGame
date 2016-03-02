using UnityEngine;
using System.Collections;
using enemySpace;

/**
 * Handling the shooting for the tank
 * Uses grip gesture with leap motion to trigger shoot
 * */

public class shootScript : MonoBehaviour {

	private HandController controller;
	public GameObject projectile;
	public GameObject explosion;
	private GameObject exp;
	private GameObject instantiatedProjectile;
	private bool shooting;
	private Vector3 shootDir;
	private Vector3 shootPos;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		shooting = false;
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HandController> ();
		audioSource = GetComponent<AudioSource> ();
	}

	
	// Update is called once per frame
	void Update () {

		//checks before shoot
		if ((controller.GetFrame ().Hands [0].GrabStrength == 1f || Input.GetKeyUp ("space")) && (!shooting)) {

			//play shoot sound
			audioSource.Play();

			shooting = true;
			shootDir = transform.forward;
			shootPos = new Vector3 (transform.position.x + transform.forward.x * 15f ,
									transform.position.y + 4f,
									transform.position.z +  transform.forward.z * 15f) ;

			//create shoot explosion
			exp = Instantiate (explosion, shootPos, new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
			
			//instantate new projectile
			instantiatedProjectile = Instantiate (projectile, shootPos, new Quaternion(0f,0f,0f,0f) ) as GameObject;
			shootDir = transform.forward;
		}

		//to move projectile
		if (shooting) {
			instantiatedProjectile.transform.position += shootDir * 6f;
		}
	}

	//set shooting
	public void setShooting(bool s) {
		shooting = s;
	}
}
