using System;
using UnityEngine; 

namespace enemySpace
{
	//class for enemy objects
	public class Enemy
	{
		private GameObject typeOfEnemy;
		private int healthOfEnemy;
		private bool enemySpawned;

		public Enemy()
		{
			typeOfEnemy = null;
			healthOfEnemy = 0;
			enemySpawned = false;
		}

		public Enemy(GameObject type, int health)
		{
			typeOfEnemy = type;
			healthOfEnemy = health;
			enemySpawned = true;
		}
			
		//movement for the enemy
		public void movement()
		{
			
		}
			
		public GameObject getEnemyObject()
		{
			return typeOfEnemy;
		}

		public int getEnemyHealth()
		{
			return healthOfEnemy;
		}

		public void decreaseEnemyHealth()
		{
			healthOfEnemy--;
		}

		public bool getSpawned()
		{
			return enemySpawned;
		}

		private void setSpawned(bool spawned)
		{
			enemySpawned = spawned;
		}
	}

	//class for the enemies projectiles
	public class enemyProjectile
	{
		private GameObject projectile;
		private bool isShot;
		private Vector3 shotDirection;

		public enemyProjectile()
		{
			projectile = null;
			isShot = false;
		}


		public enemyProjectile(GameObject proj)
		{
			projectile = proj;
			isShot = false;
		}

		// create a projectile from the enemy flying towards the player
		public void shoot(GameObject enemy, Vector3 playerPos, GameObject enemyProjectile)
		{
			Vector3 projectileSpawnPos = new Vector3 (enemy.transform.position.x, enemy.transform.position.y - 0.1f, 1f);
			projectile = GameObject.Instantiate(enemyProjectile, projectileSpawnPos, enemy.transform.rotation) as GameObject;

			//get vector towards player
			shotDirection = new Vector3(playerPos.x - projectile.transform.position.x,
				playerPos.y - projectile.transform.position.y,
				1f);

			shotDirection = 10 * shotDirection / shotDirection.magnitude;

			//add small diff to shot
			float diff = UnityEngine.Random.Range(-3, 3) / 10;
			shotDirection.x += diff;
			setIsShot (true);
		}

		public void moveProjectile()
		{
			projectile.transform.position += shotDirection * Time.deltaTime;

			if (projectile.transform.position.y < -6f)
			{
				GameObject.Destroy (projectile);
				setIsShot(false);
			}
		}

		public bool getIsShot()
		{
			return isShot;
		}

		public void setIsShot(bool fired)
		{
			isShot = fired;
		}

		public GameObject getEnemyProjectile()
		{
			return projectile;
		}

	}
}

