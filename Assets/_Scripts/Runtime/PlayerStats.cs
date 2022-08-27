using System;
using UnityEngine;

namespace _Scripts.Runtime
{
	public class PlayerStats
	{
		public event Action<int> OnMoneyChanged;
		public event Action<int> OnLivesCountChanged;

		public event Action OnChanged;

		private int _money;
		public int Money
		{
			get => _money;
			set
			{
				_money = value;
				OnChanged?.Invoke();
				OnMoneyChanged?.Invoke(_money);
			}
		}

		private int _lives;
		public int Lives
		{
			get => _lives;
			set
			{
				_lives = value;
				OnChanged?.Invoke();
				OnLivesCountChanged?.Invoke(_lives);
			}
		}

		
		public int StartMoney = 400;
		public int StartLives = 10;
	}
}