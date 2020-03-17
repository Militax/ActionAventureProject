using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Ennemy
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Zone d'attaque du Gingerbread
    /// </summary>
    public class GingerbreadAttackZone : MonoBehaviour
    {
        public float duration;
        bool canDamage;
        bool isInZone = false;
        bool isActive = false;
        Collider2D myCollider;

        void Start()
        {
            myCollider = GetComponent<Collider2D>();
            myCollider.enabled = false;
        }
        void Update()
        {
            if (myCollider.enabled && !isActive)
            {
                isActive = true;
                canDamage = true;
                StartCoroutine(Duration());
            }
            if (isInZone && canDamage)
            {
                Debug.Log("Taking Damage");
                GameManager.Instance.playerHealth--;
                canDamage = false;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter");
            if (other.CompareTag("Player"))
            {
                isInZone = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Exit");
            if (other.CompareTag("Player"))
            {
                isInZone = false;
            }
        }


        IEnumerator Duration()
        {
            yield return new WaitForSeconds(duration);
            myCollider.enabled = false;
            isActive = false;
        }

    }
}