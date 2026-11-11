using UnityEngine;

namespace Jain
{
    public class Dice : MonoBehaviour
    {
        private Rigidbody rb;

        //던지는 힘의 세기
        public float throwForce = 5f;

        //회전하는 힘의 세기
        public float torqueForce = 10f;

        //오브젝트의 물리적인 움직임이 정지
        public bool isStopped = false;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RollDice();
            }

            // 오브젝트가 물리적으로 수면 상태에 들어갔는지 확인
            if (rb.IsSleeping() && !isStopped)
            {
                isStopped = true;
            }
            // 다시 움직이기 시작하면 상태 리셋
            else if (!rb.IsSleeping() && isStopped)
            {
                isStopped = false;
            }
        }

        public void RollDice()
        {
            Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(forceDirection * throwForce, ForceMode.Impulse);

            Vector3 randomTorque = new Vector3(Random.Range(-torqueForce, torqueForce), Random.Range(-torqueForce, torqueForce), Random.Range(-torqueForce, torqueForce));
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }
    }
}
