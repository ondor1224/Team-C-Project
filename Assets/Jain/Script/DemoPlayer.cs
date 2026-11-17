using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jain
{
    public class DemoPlayer : MonoBehaviour
    {
        public float hp;

        public GameObject playerRadius;

        float time;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            EnemyAbility enemyAbility = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAbility>();

            if (other.tag == "EnemyAttack")
            {
                Destroy(other.gameObject);
                hp -= enemy.damage;

                Die();
            }
            if (enemyAbility.position == 3 && other.tag == "Enemy")
            {
                hp -= enemy.damage;
                Debug.Log(hp);

                Die();
            }
        }

        void Die()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject obj in enemies)
            {
                Enemy enemy = obj.GetComponent<Enemy>();

                if (hp < 1f)
                {
                    Destroy(gameObject);
                    Destroy(playerRadius);
                    enemy.radiusCheck = false;
                    Debug.Log("임시 플레이어가 삭제됨!");
                }
            }
        }
    }
}
