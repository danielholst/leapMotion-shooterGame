using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;

		//destroy projectile after a short while
		if (timer > 1.4f) {
			Destroy (gameObject);

			//set shooting to false to be able to shoot again
			GameObject.FindGameObjectWithTag ("Tank").GetComponent<shootScript> ().setShooting (false);
		}
	}
}
