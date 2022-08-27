using System;
using _Scripts.Core;
using _Scripts.ScriptableObjects;
using UnityEngine;

namespace _Scripts.Runtime
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private Transform target;
		private int _waypointIndex = 0;
		[SerializeField] private int nextWayIndex;
		[SerializeField] private EnemyData enemyData;
		void Start()
		{
			target = Waypoints.Points[0];
		}
		
		private void OnEnable()
		{
			target = Waypoints.Points[0];
			_waypointIndex = 0;
		}

		void Update()
		{
			var dir = target.position - transform.position;
			transform.Translate(dir.normalized * enemyData.speed * Time.deltaTime, Space.World);

			if (Vector3.Distance(transform.position, target.position) <= 0.4f)
			{
				GetNextWaypoint();
			}
		}

		private void GetNextWaypoint()
		{
			if (_waypointIndex >= Waypoints.Points.Length - 1)
			{
				EndPath();
				return;
			}
		
			_waypointIndex += nextWayIndex;
			target = Waypoints.Points[_waypointIndex];
		}

		private void EndPath()
		{
			Instantiate(enemyData.damagePalaceParticle, transform.position, transform.rotation);
			GameManager.Instance.PlayerStats.Lives -= enemyData.enemyDamage;
			gameObject.SetActive(false);
		}
	}
}
