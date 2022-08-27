using System.Globalization;
using _Scripts.Runtime;
using TMPro;
using UnityEngine;

namespace _Scripts.Core
{
    public class UIController : Singleton<UIController>
    {
	    [SerializeField] public GameObject turretPlacementText;
		[SerializeField] private TMP_Text waveLevelGameOverScreen;
		[SerializeField] private TMP_Text killCountText;
		public GameObject chooseTowerScreen;
		public GameObject towerSellScreen;
		public TMP_Text money;
		public GameObject gameOverUI;
		public GameObject hud;
		public TMP_Text lives;
		public TMP_Text waveLevelHud;
		private new Camera camera;

		public int killCount;
		public int waveCount = 0;
		
		
		void Start()
		{
			var playerStats = GameManager.Instance.PlayerStats;
			playerStats.OnChanged += UpdateUI;
			GameManager.Instance.OnLose += OnGameLose;
			GameManager.Instance.buildManager.OnSelectedNodeChanged += OnSelectNode;
			
			UpdateUI();
			camera = Camera.main;
			waveLevelHud.text = waveCount.ToString();
			Time.timeScale = 0;
		}
		private void OnDestroy()
		{
			var playerStats = GameManager.Instance.PlayerStats;
			playerStats.OnChanged -= UpdateUI;
			GameManager.Instance.OnLose -= OnGameLose;
			GameManager.Instance.buildManager.OnSelectedNodeChanged -= OnSelectNode;
		}
		
		private void FilledNodeSelected(Node node)
		{
			var pos = camera.WorldToScreenPoint(node.gameObject.transform.position);

			chooseTowerScreen.SetActive(false);
			towerSellScreen.SetActive(true);
			towerSellScreen.transform.position = pos;
		}
		private void EmptyNodeSelected(Node node)
		{
			var pos = camera.WorldToScreenPoint(node.gameObject.transform.position);

			turretPlacementText.SetActive(false);
			towerSellScreen.SetActive(false);
			chooseTowerScreen.SetActive(true);
			chooseTowerScreen.transform.position = pos;
		}
		
		private void UpdateUI()
		{
			money.text = GameManager.Instance.PlayerStats.Money.ToString();
			lives.text = GameManager.Instance.PlayerStats.Lives.ToString();
		}

		private void OnSelectNode(Node node)
		{
			Debug.Log(node);
			if(node.IsEmpty)
				EmptyNodeSelected(node);
			else
				FilledNodeSelected(node);
		}
		
		
		

		private void OnGameLose()
		{
			gameOverUI.SetActive(true);
			hud.SetActive(false);
			waveLevelGameOverScreen.text = waveCount.ToString();
			killCountText.text = GameManager.Instance.killCount.ToString();
			Time.timeScale = 0;
		}
    }
}
