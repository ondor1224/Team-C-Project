using UnityEngine;

namespace Jain
{
    public class Boss : MonoBehaviour
    {
        public int position;

        Enemy enemy;

        void Start()
        {
            enemy = GetComponent<Enemy>();

            if (position == 1)
            {
                enemy.damage = 10f;
                enemy.speed = 0.4f;
            }
        }

        void Update()
        {
            
        }

        private void OnDestroy()
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            gameManager.bossCheck = 0;
            gameManager.stageTime = 0f;
            gameManager.stage += 1;
        }
    }
}
