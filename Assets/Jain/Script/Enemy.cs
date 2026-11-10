using UnityEngine;

namespace Jain
{
    public class Enemy : MonoBehaviour
    {
        //적의 이동속도를 조절함
        public float speed;

        void Start()
        {

        }

        void Update()
        {
            //적을 이동시킴
            transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            //닿은 오브젝트의 태그가 PlayerTower인지 검사함
            if (other.tag == "PlayerTower")
            {
                Debug.Log("PlayerTower가 데미지를 입음");
                Destroy(gameObject);
            }
        }
    }
}
