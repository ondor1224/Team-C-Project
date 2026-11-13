using UnityEngine;

namespace Jain
{
    public class Bullet : MonoBehaviour
    {
        public float speed;

        void Start()
        {
            Destroy(gameObject, 2f);
        }

        void Update()
        {
            transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
        }
    }
}
