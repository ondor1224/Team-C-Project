using UnityEngine;

namespace Jain
{
    public class Boss : MonoBehaviour
    {
        void Start()
        {
            
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
