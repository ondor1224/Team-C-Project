using UnityEngine;

namespace MyeongChan
{

    public class Player : MonoBehaviour
    {
        public float speed;

        void Start()
        {
        
        }

      
        void Update()
        {
            transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        }
    }
}
