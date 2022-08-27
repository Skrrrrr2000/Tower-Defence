using UnityEngine;

namespace _Scripts.Runtime
{
	public class Bullet : MonoBehaviour
	{
		private Transform _target;
		public float speed;
		public float bulletdamage;
		public GameObject impactEffect;

		private void Update()
		{

			if (_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var dir = _target.position - transform.position;
			var distanceThisFrame = speed * Time.deltaTime;

			if (dir.magnitude <= distanceThisFrame)
			{
				HitTarget();
				return;
			}

			transform.Translate(dir.normalized * distanceThisFrame, Space.World);;

		}

		public void Seek(Transform _target)
		{
			this._target = _target;
		}

		private void HitTarget()
		{
			var effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(effectIns, 5f);
			Destroy(gameObject);
			Damage(_target);
		}
		
		private void Damage(Transform enemy)
		{
			var e = enemy.GetComponent<Enemy>();

			if (e != null)
			{
				e.TakeDamage(bulletdamage);
			}
		}
		  
	}
}
