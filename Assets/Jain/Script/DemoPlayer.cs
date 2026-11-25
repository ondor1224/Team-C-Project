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
            if (other.tag == "Bullet")
            {
                Bullet bullet = other.GetComponent<Bullet>();
                Destroy(other.gameObject);
                hp -= bullet.damage;

                Die();
            }
            if (other.tag == "Attack")
            {
                Attack attack = other.GetComponent<Attack>();
                Destroy(other.gameObject);
                hp -= attack.damage;

                Die();
            }
            if (other.tag == "Enemy")
            {
                Enemy enemy = other.GetComponent<Enemy>();
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
