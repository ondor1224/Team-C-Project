using UnityEngine;

namespace Jain
{
    public class Attack : MonoBehaviour
    {
        public float damage;

        void Start()
        {
            Destroy(gameObject, 1f);
        }

        void Update()
        {
        
        }
    }
}
