using UnityEngine;

namespace _Scripts.Runtime
{
	public class Towers : MonoBehaviour
	{
		private Transform _target;
		public Transform headRotation;
		public Transform firePoint;
		public static int TurretPlacementCount;
		private float _fireCountdown = 0f;
		public string enemyTag = "Enemy";
		[SerializeField] public TowerInfo towerData;
		void Start()
		{
			InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
		}

		public void UpdateTarget()
		{
			var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
			var shortestDistance = Mathf.Infinity;
			GameObject nearestEnemy = null;
			foreach (GameObject enemy in enemies)
			{
				var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance)
				{
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}

			if (nearestEnemy != null && shortestDistance <= towerData.range)
			{
				_target = nearestEnemy.transform;
			}
			else
			{
				_target = null;
			}

		}

		void Update()
		{
			if (_target == null)
			{			
				return;
			}

			LockOnTarget();
	
			if (_fireCountdown <= 0f)
			{
				Shoot();
				_fireCountdown = 1f / towerData.fireRate;
			}
			_fireCountdown -= Time.deltaTime;		

		}

		private void LockOnTarget()
		{
			var dir = _target.position - transform.position;
			var rotatedVectorDir = Quaternion.Euler(0, 0, 0) * dir;
			var lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
			var rotation = Quaternion.Lerp(headRotation.rotation, lookRotation, Time.deltaTime * towerData.turnSpeed);
			headRotation.rotation = rotation;

		}


		private void Shoot()
		{
			var bulletGo = (GameObject)Instantiate(towerData.bulletPrefab, firePoint.position, firePoint.rotation);
			var bullet = bulletGo.GetComponent<Bullet>();
			bullet.bulletdamage = towerData.bulletDamage;
			bullet.speed = towerData.bulletSpeed;
			
			if (bullet != null)
				bullet.Seek(_target);
		}

		public void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, towerData.range);
		}
	}
}