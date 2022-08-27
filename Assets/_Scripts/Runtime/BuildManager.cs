using System;
using UnityEngine;

namespace _Scripts.Runtime
{
	public class BuildManager: MonoBehaviour
	{
		public event Action<Node> OnSelectedNodeChanged;
		
		public Towers[] towerPrefab;
		
		private Node _selectedNode;
		public Node SelectedNode
		{
			get => _selectedNode;
			set
			{
				_selectedNode = value;
				OnSelectedNodeChanged?.Invoke(_selectedNode);
			}
		}
		
		public void GetTurretToBuild(int towerID)
		{
			Time.timeScale = 1;
			BuildTurret(towerPrefab[towerID]);
		}

		public void SellTurretOnNode()
		{
			SellTurret();
		}
		
		private void BuildTurret(Towers prefab)
		{
			if(_selectedNode.IsEmpty)
				_selectedNode.Build(prefab);
		}
		private void SellTurret()
		{
			if(!_selectedNode.IsEmpty)
				_selectedNode.Sell();
		}
	}
}
