﻿using UnityEngine;
using System.Collections;
using enemySpace;
using System.Collections.Generic;

public class enemyHandler : MonoBehaviour {

	private GameObject player;
	public GameObject enemyTank;
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

			//move enemy projectiles

			//if enemy is spawned
			if (enemies[i].getEnemyObject () != null) {

				//Move enemies
				enemies[i].movement();
			}
		}




	}

	public float getDistanceToPlayer(Vector3 playerPos) {

		return Mathf.Sqrt(Mathf.Abs(  Mathf.Pow(transform.position.x - playerPos.x,2)
									+ Mathf.Pow(transform.position.y - playerPos.y,2)
									+ Mathf.Pow(transform.position.z - playerPos.z,2)));
		
	}

 	void spawnNewEnemy() {
		
		GameObject enemyObject;
		Vector3 pos = new Vector3 (120f, 0f, 50);

		enemyObject = Instantiate (enemyTank, pos, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;

		enemies.Add(new Enemy (enemyObject, 1));

		print ("Enemy spawned");

	}


}
