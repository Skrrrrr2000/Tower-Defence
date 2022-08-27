using System;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Runtime
{
	public class Node : MonoBehaviour
	{
		public Color hoverColor;
		private Renderer _rend;
		private Color _startColor;
		public static Action OnEmptyNodeClick;
		public static Action OnFilledNodeClick;
		
		public Towers turret;



		public bool IsEmpty => !turret;
		
		void Start()
		{
			_rend = GetComponent<Renderer>();
			_startColor = _rend.material.color;
		}

		private void OnMouseUp()
		{
			GameManager.Instance.buildManager.SelectedNode = this;

			if (turret != null)
			{
				return;
			}

		}
		
		
		private void OnMouseEnter()
		{
			if (Towers.TurretPlacementCount <=5)
			{
				_rend.material.color = hoverColor;
			}
		}

		private void OnMouseExit()
		{
			_rend.material.color = _startColor;
		}


		public void Build(Towers prefab)
		{
			Towers.TurretPlacementCount++;
			turret = Instantiate(prefab, transform.position, Quaternion.identity);
			GameManager.Instance.PlayerStats.Money -= turret.towerData.cost;
			UIController.Instance.chooseTowerScreen.SetActive(false);
		}
		public void Sell()
		{
			Destroy(turret.gameObject);
			var towerData = turret.GetComponent<Towers>().towerData;
			GameManager.Instance.PlayerStats.Money += towerData.cost;
			UIController.Instance.towerSellScreen.SetActive(false);
		}

	}
}
