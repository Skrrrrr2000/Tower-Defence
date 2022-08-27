using System;
using _Scripts.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Core
{
	public class GameManager : Singleton<GameManager>
	{
		public event Action OnLose; 

		public int killCount;

		public readonly PlayerStats PlayerStats = new PlayerStats();
		[HideInInspector]
		public BuildManager buildManager;

		protected override void Awake()
		{
			base.Awake();
			buildManager = FindObjectOfType<BuildManager>();
		}

		private void Start()
		{
			PlayerStats.OnLivesCountChanged += OnLiveCountChanged;

			PlayerStats.Money = PlayerStats.StartMoney;
			PlayerStats.Lives = PlayerStats.StartLives;
		}
		private void OnDestroy()
		{
			PlayerStats.OnLivesCountChanged -= OnLiveCountChanged;
		}

		
		private void OnLiveCountChanged(int livesCount)
		{
			if(livesCount <= 0)
				OnLose?.Invoke();
		}

		public void RestartLevel()
		{
			PlayerStats.Lives = PlayerStats.StartLives;
			PlayerStats.Money = PlayerStats.StartMoney;

			UIController.Instance.killCount = 0;
			Towers.TurretPlacementCount = 0;
			SceneManager.LoadScene(0);
		}
	}
}