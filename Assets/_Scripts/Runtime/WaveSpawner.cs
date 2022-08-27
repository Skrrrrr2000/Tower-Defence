using System.Collections;
using _Scripts.Core;
using _Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace _Scripts.Runtime
{
	public class WaveSpawner : MonoBehaviour
	{
		private ObjectPooler _objectPooler;
		public Wave[] waves;
		public Transform spawnPoint;
		public float timeBetweenWaves;
		private float _countdown = 2f;
		public int waveIndex = 4;
		
		private void Start()
		{
			_objectPooler = FindObjectOfType<ObjectPooler>();
		}

		void Update()
		{
			if (_countdown <= 0f)
			{
				StartCoroutine(SpawnWave());
				_countdown = timeBetweenWaves;
				return;
			}

			_countdown -= Time.deltaTime;

		}

		private IEnumerator SpawnWave()
		{
			UIController.Instance.waveCount++;
			UIController.Instance.waveLevelHud.text = UIController.Instance.waveCount.ToString();

			for (int i = 0; i < waveIndex; i++)
			{
				var wave = waves[Random.Range(0,4)];
				SpawnEnemy(wave.Name);
				yield return new WaitForSeconds(1f / wave.rate);
			}
			waveIndex++;
			timeBetweenWaves++;
		}

		private void SpawnEnemy(string enemy)
		{
			_objectPooler.SpawnFromPool(enemy, spawnPoint.position, Quaternion.identity);
		}
	}
}
