using Codice.CM.Common;
using System.Collections;
using UnityEngine;

namespace Jain
{
    public class OGAttack : MonoBehaviour
    {
        public float speed;
        public GameObject PlayerBullet;

        void Start()
        {
            StartCoroutine(CloseUpAttack());
        }


        //총알 움직이는거
        void Update()
        {
            transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
        }

        //총알 스폰
        IEnumerator CloseUpAttack()
        
            {
                while (true)
                {
                GameObject bullet = Instantiate(PlayerBullet, transform.position + new Vector3(-1f, 0f, 0f), transform.rotation);
                
                yield return new WaitForSeconds(1);
                Destroy(bullet);
                yield return new WaitForSeconds(0.1f);

                }
            }
    }
}