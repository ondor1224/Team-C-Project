using UnityEditor;
using UnityEngine;

namespace Jain
{
    public class DemoPlayer : MonoBehaviour
    {
        public float hp;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

            if (other.tag == "EnemyAttack")
            {
                hp -= enemy.damage;
            }
        }
    }
}
