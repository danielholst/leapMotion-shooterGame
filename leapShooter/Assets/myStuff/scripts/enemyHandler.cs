using UnityEngine;
using System.Collections;
using enemySpace;
using System.Collections.Generic;

public class enemyHandler : MonoBehaviour {

	private GameObject player;
	public GameObject enemyTank;
	public GameObject explosion;
	private GameObject exp;
	private GameObject instantiatedTank;
	private List<Enemy> enemies = new List<Enemy> (); 
	private float timer;
	private int enemiesSpawned;

	// Use this for initialization
	void Start () {
		
		enemiesSpawned = 0;
		timer = 0f;
		player = GameObject.FindGameObjectWithTag ("Tank");
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer > 1 && enemiesSpawned == 0) {
			enemiesSpawned++;
			spawnNewEnemy ();
		}

		for (int i = 0; i < enemies.Count; i++) {

			//if enemy is spawned
			if (enemies [i].getEnemyObject () != null) {
				enemies [i].handleEnemy (player.transform.position);
			} else if (enemies [i].getEnemyObject () == null && enemies [i].getProjectile () != null)
				enemies [i].destroyProjectile ();
		}
	}

 	void spawnNewEnemy() {
		
		GameObject enemyObject;
		//randomize start pos TODO
		Vector3 pos = new Vector3 (120f, 0f, 50);

		enemyObject = Instantiate (enemyTank, pos, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		enemies.Add(new Enemy (enemyObject, 1, explosion));
	}
}
