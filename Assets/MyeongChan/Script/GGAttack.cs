using Codice.CM.Common;
using System.Collections;
using UnityEngine;

namespace Jain
{
    public class GGAttack : MonoBehaviour
    {
    
        public GameObject PlayerBullet;
        public float speed;

        void Start()
        {
            StartCoroutine(CloseUpAttack());
        }

        void Update()
        {
          
        }

        IEnumerator CloseUpAttack()

        {
            while (true)
            {
                GameObject bullet = Instantiate(PlayerBullet, transform.position + new Vector3(-4f, 0f, 0f), transform.rotation);

                yield return new WaitForSeconds(0.1f);
                Destroy(bullet);
                yield return new WaitForSeconds(1.5f);

            }
        }
        
    }
}