using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Jain
{
    public class EnemyAbility : MonoBehaviour
    {
        //몹이 가지는 포지션
        public int position;

        //대쉬를 했을때 날라가는 정도
        public float dashSpeed;

        //대쉬를 한 상태인지 체크
        bool isDashing = false;

        //공격 딜레이
        float attackDelta;

        Vector3 startingPoint;

        public GameObject bullet;
        public GameObject attack;

        ///컴포넌트
        Rigidbody rb;
        Enemy enemy;
        GameManager gameManager;
        Animator anim;

        public int haddon;

        void Start()
        {
            anim = GetComponent<Animator>();
            enemy = GetComponent<Enemy>();
            rb = GetComponent<Rigidbody>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            position = Random.Range(1, 4);
            haddon =  gameManager.stage > 6 ? Random.Range(0, 100) : 100;
            if (!(haddon <= 10))
            {
                if (position == 1)
                {
                    enemy.damage = 1.2f;
                    enemy.speed = 1.2f;
                }
                else if (position == 2)
                {
                    enemy.damage = 3f;
                    enemy.speed = 1.2f;
                }
                else if (position == 3)
                {
                    enemy.damage = 3.8f;
                    enemy.speed = 0.5f;
                }
            }
            else
            {
                position = 4;
                enemy.damage = 6.5f;
                enemy.speed = 2.3f;
            }
        }

        void Update()
        {
            DeltaMin();
            if (enemy.radiusCheck)
            {
                if (attackDelta <= 0f)
                {
                    Throw();
                    Hit();
                    if (position == 3)
                    {
                        if (!isDashing)
                        {
                            StartCoroutine(Dash());
                        }
                    }
                }
            }
        }

        void DeltaMin()
        {
            if (attackDelta > 0f)
            {
                attackDelta -= Time.deltaTime;
            }
        }

        //원거리
        void Throw()
        {
            if (position == 1)
            {
                if (attackDelta <= 0f)
                {
                    GameObject bulletMob = Instantiate(bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
                    Bullet bulletScript = bulletMob.GetComponent<Bullet>();
                    bulletScript.damage = enemy.damage;
                    anim.SetTrigger("Attack");
                    attackDelta = 0.75f;
                }
            }
        }

        //근거리
        void Hit()
        {
            if (position == 2)
            {
                if (attackDelta <= 0f)
                {
                    GameObject attackMob = Instantiate(attack, transform.position + new Vector3(1f, 0.5f, 0f), attack.transform.rotation);
                    Attack attackScript = attackMob.GetComponent<Attack>();
                    attackScript.damage = enemy.damage;
                    anim.SetTrigger("Attack");
                    attackDelta = 1.2f;
                }
            }
        }

        //돌격형
        private IEnumerator Dash()
        {
            anim.SetTrigger("Dash");
            attackDelta = 3f;
            isDashing = true;
            startingPoint = transform.position;
            rb.linearVelocity = Vector3.right * dashSpeed;
            yield return new WaitForSeconds(0.5f);
            rb.linearVelocity = Vector3.zero;
            startingPoint.x += -1f;
            transform.position = startingPoint;
            enemy.radiusCheck = false;
            isDashing = false;
        }
    }
}