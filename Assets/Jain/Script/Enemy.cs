using UnityEngine;

namespace Jain
{
    public class Enemy : MonoBehaviour
    {
        //적의 기본 데미지
        public float damage;

        //적의 이동속도를 조절함
        public float speed;

        //플레이어 범위에 들어왔나?
        public bool radiusCheck;

        void Start()
        {

        }

        void Update()
        {
            if (!radiusCheck)
            {
                Move();
            }
        }

        void Move()
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
            //플레이어의 범위 안에 들어온 적들의 움직임을 정지함
            if  (other.name == "PlayerRadius")
            {
                Debug.Log("플레이어의 범위 안에 들어왔음");
                radiusCheck = true;
            }
        }
    }
}
