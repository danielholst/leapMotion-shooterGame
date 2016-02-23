using System.Collections;
using UnityEngine; 
using System.Linq;

namespace enemySpace
{
	//class for enemy objects
	public class Enemy
	{
		private GameObject enemyObj;
		private int healthOfEnemy;
		private bool enemySpawned;
		private enemyProjectile projectile;
		private GameObject proj;

		public Enemy()
		{
			enemyObj = null;
			healthOfEnemy = 0;
			enemySpawned = false;
			projectile = new enemyProjectile ();
			proj = GameObject.FindGameObjectWithTag ("EnemyProjectile");
			//proj = Resources.FindObjectsOfTypeAll (typeof(GameObject)).Cast<GameObject> ().Where (g => g.tag == "EnemyProjectile");
		}

		public Enemy(GameObject type, int health)
		{
			enemyObj = type;
			healthOfEnemy = health;
			enemySpawned = true;
			proj = GameObject.FindGameObjectWithTag ("EnemyProjectile");
			//proj = Resources.FindObjectsOfTypeAll (typeof(GameObject)).Cast<GameObject> ().Where (g => g.tag == "EnemyProjectile");
			projectile = new enemyProjectile (proj);
		}

		public void handleEnemy(Vector3 playerPos) {

			//Move enemies
			movement();

			//handle projectile
			projectile.handleProjectile (enemyObj.transform.position, playerPos); 
		}


		//shoot function for enemy
		public void shoot(Vector3 playerPos)
		{
			if (proj == null)
				MonoBehaviour.print ("hej");

			//projectile.shoot (enemyObj.transform.position, dir);

		}

		public enemyProjectile getProjectile() {
			return projectile;
		}
			
		//movement for the enemy
		public void movement()
		{
			//print ("mov");
			enemyObj.transform.position += new Vector3 (0.3f,0f,0.0f);
		}
			
		public GameObject getEnemyObject()
		{
			return enemyObj;
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
		private GameObject projectileInstance;
		private bool isShot;
		private Vector3 shotDirection;
		private float timer;

		public enemyProjectile()
		{
			projectile = null;
			isShot = false;
			timer = 0f;
		}


		public enemyProjectile(GameObject proj)
		{
			projectile = proj;
			isShot = false;
			timer = 0f;
		}

		public void handleProjectile(Vector3 pos, Vector3 playerPos) {

			if (projectileInstance == null && getIsShot() == true)
				setIsShot (false);


			timer += Time.deltaTime;
			if (timer >= 1f) {
				timer = 0f;
				GameObject.Destroy (projectileInstance);
				setIsShot (false);
			}

			//move enemy projectiles
			if (getIsShot ())
				moveProjectile ();

			if (!getIsShot ())
				shoot (pos, playerPos);

		}

		// create a projectile from the enemy flying towards the player
		public void shoot(Vector3 pos, Vector3 playerPos)
		{
			//get direction from enemy towards player
			Vector3 dir = new Vector3(  playerPos.x - pos.x,
										playerPos.y - pos.y,
										playerPos.z - pos.z);
			projectileInstance = GameObject.Instantiate(projectile, pos, new Quaternion(0f,0f,0f,0f)) as GameObject;

			shotDirection = dir;

			//add small diff to shot
			float diff = UnityEngine.Random.Range(-2, 2);
			float diff2 = UnityEngine.Random.Range(-2, 2);
			shotDirection.x += diff;
			shotDirection.z += diff2;
			setIsShot (true);
		}

		public void moveProjectile()
		{
			projectileInstance.transform.position += shotDirection * Time.deltaTime;
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

