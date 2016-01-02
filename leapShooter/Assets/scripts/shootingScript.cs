using UnityEngine;
using System.Collections;

public class shootingScript : MonoBehaviour {

	public GameObject projectile;
	private float shootingSpeed;
	private Vector3 projectileSpawn;
	private GameObject instantiatedProjectile;
	private bool shooting;

	// Use this for initialization
	void Start () {
		shootingSpeed = 0.01f;
		projectile.GetComponent<Renderer> ().enabled = false;
		projectileSpawn = new Vector3 (0f, 0f, 0f);
		shooting = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.F)) {

			shooting = true;
			projectile.GetComponent<Renderer> ().enabled = true;

			//get spawn pos for projectile
			projectileSpawn.Set(transform.position.x, 1f, transform.position.z);

			//instantate new projectile
			instantiatedProjectile = Instantiate(projectile,projectileSpawn,transform.rotation)as GameObject;

		}

		if (shooting) {
			instantiatedProjectile.transform.position += new Vector3 (0f, 0f, shootingSpeed);
			print (instantiatedProjectile.transform.position);
		}
	}
}
