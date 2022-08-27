using System;
using UnityEngine;

namespace _Scripts.Runtime
{
	[CreateAssetMenu(fileName = "TowerData", menuName = "TestProject/TowerData")]
	public class TowerInfo : ScriptableObject
	{
		public int cost;
		public float range = 2f;
		public float turnSpeed = 10f;
		public float fireRate = 1f;
		public float bulletDamage = 50;
		public float bulletSpeed = 15;
		public GameObject bulletPrefab;
	}
}
