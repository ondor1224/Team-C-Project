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
