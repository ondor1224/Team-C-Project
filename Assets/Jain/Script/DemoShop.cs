using UnityEngine;

namespace Jain
{
    public class DemoShop : MonoBehaviour
    {
        public GameObject shop;
        
        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public void ExitBtn()
        {
            shop.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
