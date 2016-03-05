using System.Collections;
using UnityEngine; 
using System.Linq;

namespace enemySpace
{
	//class for enemy objects
	public class Enemy
	{
		private GameObject enemyObj;
		private enemyProjectile projectile;
		private GameObject proj;
		private Transform playerTrans;

		//enemy default constructor
		public Enemy()
		{
			enemyObj = null;;
			projectile = new enemyProjectile ();
			proj = GameObject.FindGameObjectWithTag ("EnemyProjectile");
			playerTrans = GameObject.FindGameObjectWithTag ("Tank").transform;
			//proj = Resources.FindObjectsOfTypeAll (typeof(GameObject)).Cast<GameObject> ().Where (g => g.tag == "EnemyProjectile");
		}

		//enemy constructor
		public Enemy(GameObject type, GameObject exp)
		{
			enemyObj = type;
			proj = GameObject.FindGameObjectWithTag ("EnemyProjectile");
			//proj = Resources.FindObjectsOfTypeAll (typeof(GameObject)).Cast<GameObject> ().Where (g => g.tag == "EnemyProjectile");
			projectile = new enemyProjectile (proj, exp);
			playerTrans = GameObject.FindGameObjectWithTag ("Tank").transform;
		}

		//handles movement and projectiles for enemy
		public void handleEnemy(Vector3 playerPos) {

			//Move enemies
			movement();

			//handle projectile
			projectile.handleProjectile (enemyObj.transform, playerPos); 
		}

		//get projectile object
		public enemyProjectile getProjectile() {
			return projectile;
		}

		//destroy the created projectile
		public void destroyProjectile() {
			projectile.destroyInstantiated ();
		}
			
		//movement for the enemy
		public void movement()
		{
			//first fix rotation towards player then move towards player if to far away
			enemyObj.transform.LookAt(playerTrans);

			if (getDistanceToPlayer () > 120f)
				enemyObj.transform.position += enemyObj.transform.forward * 0.3f;
			//enemyObj.transform.position += new Vector3 (0.3f,0f,0.0f);
		}

		// returns the distance to the player tank
		float getDistanceToPlayer() {

			return Mathf.Sqrt(Mathf.Abs(  Mathf.Pow(enemyObj.transform.position.x - playerTrans.position.x,2)
										+ Mathf.Pow(enemyObj.transform.position.y - playerTrans.position.y,2)
										+ Mathf.Pow(enemyObj.transform.position.z - playerTrans.position.z,2)));	
		}

		//returns enemy object
		public GameObject getEnemyObject()
		{
			return enemyObj;
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
		private GameObject explosion;
		private GameObject instantiatedExplosion;

		//Default constructor
		public enemyProjectile()
		{
			projectile = null;
			isShot = false;
			timer = 0f;
			explosion = null;
		}

		//constructor
		public enemyProjectile(GameObject proj, GameObject exp)
		{
			projectile = proj;
			isShot = false;
			timer = 0f;
			explosion = exp;
		}

		//handles the spawn and translation of the projectile
		public void handleProjectile(Transform trans, Vector3 playerPos) {

			//if projectile was destroyed set isShot = false
			if (projectileInstance == null && getIsShot() == true)
				setIsShot (false);

			// timer for projectile life time
			timer += Time.deltaTime;
			if (timer >= 3f) {
				timer = 0f;
				GameObject.Destroy (projectileInstance);
				setIsShot (false);
			}

			//move enemy projectiles
			if (getIsShot ())
				moveProjectile ();

			//if not shot, shoot!
			if (!getIsShot () && timer >= 2.5f)
				shoot (trans, playerPos);

		}

		// create a projectile from the enemy flying towards the player
		public void shoot(Transform enemyTrans, Vector3 playerPos)
		{
			//adjust spawn position 
			Vector3 spawnPos = new Vector3 (enemyTrans.position.x + enemyTrans.forward.x * 20f ,
											enemyTrans.position.y + 4f,
											enemyTrans.position.z +  enemyTrans.forward.z * 20f);

			//create explosion effect when shooting
			instantiatedExplosion = GameObject.Instantiate(explosion, spawnPos, new Quaternion (0f, 0f, 0f, 0f)) as GameObject;

			//create projectile
			projectileInstance = GameObject.Instantiate(projectile, spawnPos, new Quaternion(0f,0f,0f,0f)) as GameObject;

			//get direction from enemy towards player with small diff
			shotDirection = new Vector3(    enemyTrans.forward.x + (UnityEngine.Random.Range (-2f, 2f) / 10f),
											0f,
											enemyTrans.forward.z +(UnityEngine.Random.Range (-2f, 2f) / 10f));
			

			setIsShot (true);
		}

		//moves projectile
		public void moveProjectile()
		{
			projectileInstance.transform.position += shotDirection * 4f;
		}

		//returns if projectile is shot
		public bool getIsShot()
		{
			return isShot;
		}

		//set if projectile is shot
		public void setIsShot(bool fired)
		{
			isShot = fired;
		}

		//destroy projectile instance
		public void destroyInstantiated() {
			GameObject.Destroy (projectileInstance);
		}

		//get projectile object
		public GameObject getEnemyProjectile()
		{
			return projectile;
		}
	}
}

