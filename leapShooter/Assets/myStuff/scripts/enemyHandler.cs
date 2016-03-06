using UnityEngine;
using System.Collections;
using System.Timers;
using enemySpace;
using System.Collections.Generic;

/**
 * Handles the enemies and where and when they are spawned
 **/

public class enemyHandler : MonoBehaviour {

	private GameObject player;
	public GameObject enemyTank;
	public GameObject explosion;
	private GameObject scoreObject;
	private GameObject exp;
	private GameObject instantiatedTank;
	private List<Enemy> enemies = new List<Enemy> (); 
	private int timer;
	private int enemiesSpawned;
	private int score;
	//private Timer timer;


	IEnumerator Start () {
	
		enemiesSpawned = 0;
		player = GameObject.FindGameObjectWithTag ("Tank");
		timer = 0;
		score = 0;
		scoreObject = GameObject.FindGameObjectWithTag ("Score");
		yield return StartCoroutine(spawnUpdate());
		yield return new WaitForSeconds (2f);
	}

	IEnumerator spawnUpdate() {

		while (timer < 30) {
			timer++;
			enemiesSpawned++;
			spawnNewEnemy ();

			if (timer < 6) {
				yield return new WaitForSeconds(7f);
			}
			else if (timer > 6 && timer < 12) {
				yield return new WaitForSeconds(5f);
			}
			else if (timer > 12 && timer < 18) {
				yield return new WaitForSeconds(4f);
			}
			else if (timer > 18 ) {
				yield return new WaitForSeconds(3f);
			}
		}

		Application.LoadLevel (0);
	}

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {

		score = 0;

		for (int i = 0; i < enemies.Count; i++) {

			//if enemy is spawned
			if (enemies [i].getEnemyObject () != null) {
				enemies [i].handleEnemy (player.transform.position);
			} else if (enemies [i].getEnemyObject () == null && enemies [i].getProjectile () != null)
				enemies [i].destroyProjectile ();

			if (enemies [i].getEnemyObject() == null)
				score++;
		}

		//set score
		scoreObject.GetComponent<scoreScript> ().setScore (score);

	}

	//handles the spawn of all new enemies
	void spawnHandler() {
		if ((timer > 1 && enemiesSpawned == 0) ||
			(timer > 6 && enemiesSpawned == 1) ||
			(timer > 10 && enemiesSpawned == 2) ||
			(timer > 15 && enemiesSpawned == 3) ||
			(timer > 25 && enemiesSpawned == 4 )) {
			enemiesSpawned++;
			spawnNewEnemy ();

		}
	}

	//spawns a new enemy at random position 
 	void spawnNewEnemy() {
		
		GameObject enemyObject;

		Vector3 pos = getRandomPos();


		enemyObject = Instantiate (enemyTank, pos, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		enemies.Add(new Enemy (enemyObject, explosion));
	}

	//get random position on the game field without spawning close to player
	Vector3 getRandomPos() {

		Vector3 pos = new Vector3 (-10f, 0f, 0f);
		do {
			pos.x = UnityEngine.Random.Range (-200f, 200f);
			pos.y = 0f;
			pos.z = UnityEngine.Random.Range (-200f, 200f);
		} while (getDistanceToPlayer (pos) < 130f);

		return pos;
	}

	//returns distance to player
	float getDistanceToPlayer(Vector3 pos) {

		return Mathf.Sqrt(Mathf.Abs(  Mathf.Pow(pos.x - player.transform.position.x,2)
									+ Mathf.Pow(pos.y - player.transform.position.y,2)
									+ Mathf.Pow(pos.z - player.transform.position.z,2)));	
	}
}
