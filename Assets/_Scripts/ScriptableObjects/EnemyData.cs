using UnityEngine;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "TestProject/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float health;
        public int worth = 50;
        public float speed = 5;
        public GameObject damagePalaceParticle;
        public int enemyDamage;
    }
}
