using UnityEngine;

namespace _Scripts.ScriptableObjects
{
	[CreateAssetMenu(fileName = "WaveData", menuName = "TestProject/WaveData")]
	public class Wave : ScriptableObject
	{
		public GameObject enemy;
		public float rate;
		public string Name;

	}
}