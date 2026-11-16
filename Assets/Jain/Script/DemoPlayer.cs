using System.Collections;
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

                Die();
            }
            if (other.tag == "Enemy")
            {
                hp -= enemy.damage;
                Debug.Log(hp);

                Die();
                InvincibilityTime();
            }
        }

        void Die()
        {
            if (hp < 1f)
            {
                Destroy(gameObject);
                Debug.Log("임시 플레이어가 삭제됨!");
            }
        }

        IEnumerator InvincibilityTime()
        {
            yield return new WaitForSeconds(2f);
        }
    }
}
