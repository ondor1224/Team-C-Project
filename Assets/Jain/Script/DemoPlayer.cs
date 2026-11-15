using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

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
            Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            EnemyAbility enemyAbility = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAbility>();

            if (other.tag == "EnemyAttack")
            {
                Destroy(other.gameObject);
                hp -= enemy.damage;

                if (hp < 1f)
                {
                    Destroy(gameObject);
                    Debug.Log("임시 플레이어가 삭제됨!");
                }
            }
            if (other.tag == "Enemy")
            {
                hp -= enemy.damage;

                if (hp < 1f)
                {
                    Destroy(gameObject);
                    Debug.Log("임시 플레이어가 삭제됨!");
                }
            }
        }
    }
}
