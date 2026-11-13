using UnityEngine;
using UnityEngine.UIElements;

namespace Jain
{
    public class EnemyAbility : MonoBehaviour
    {
        public int position;

        float attackDelta;

        public GameObject bullet;

        void Start()
        {
            position = Random.Range(1, 4);
        }

        void Update()
        {
            DeltaMin();
            Onedeal();
            MeleeAttack();
            CrazedWarrior();
        }

        void DeltaMin()
        {
            if (attackDelta > 0f)
            {
                attackDelta -= Time.deltaTime;
            }
        }

        //원거리
        void Onedeal()
        {
            if (position == 1)
            {
                if (attackDelta <= 0f)
                {
                    Instantiate(bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
                    attackDelta = 0.8f;
                }
            }
        }

        //근거리
        void MeleeAttack()
        {
            if (position == 2)
            {
                if (attackDelta <= 0f)
                {
                    //
                    attackDelta = 0.3f;
                }
            }
        }

        //돌격형
        void CrazedWarrior()
        {
            if (position == 3)
            {
                if (attackDelta <= 0f)
                {
                    //
                    attackDelta = 0.5f;
                }
            }
        }
    }
}
