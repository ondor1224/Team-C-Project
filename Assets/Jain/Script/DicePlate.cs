using System.Collections;
using UnityEngine;

namespace Jain
{
    public class DicePlate : MonoBehaviour
    {
        public GameObject dice;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.name)
            {
                case "1":
                    Debug.Log("주사위 : 2");
                    break;
                case "2":
                    Debug.Log("주사위 : 1");
                    break;
                case "3":
                    Debug.Log("주사위 : 4");
                    break;
                case "4":
                    Debug.Log("주사위 : 3");
                    break;
                case "5":
                    Debug.Log("주사위 : 6");
                    break;
                case "6":
                    Debug.Log("주사위 : 5");
                    break;
            }
        }
    }
}
