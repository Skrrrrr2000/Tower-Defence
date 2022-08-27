using System;
using _Scripts.Core;
using _Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Runtime
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private float health;
		public Image healthBar;
		private bool _isDead = false;
		[SerializeField] private EnemyData enemyData;

		private void Start()
		{
			health = enemyData.health;
			healthBar.fillAmount = health;
		}

		private void OnEnable()
		{
			health = enemyData.health;
			healthBar.fillAmount = health;
			_isDead = false;
		}

		public void TakeDamage(float amount)
		{
			health -= amount;
			healthBar.fillAmount = health;
			
			if (health <= 0 && !_isDead)
			{
				Die();
			}
		}
		
		private void Die()
		{
			_isDead = true;
			GameManager.Instance.PlayerStats.Money += enemyData.worth;
			GameManager.Instance.killCount++;
			gameObject.SetActive(false);
		}
	}
}