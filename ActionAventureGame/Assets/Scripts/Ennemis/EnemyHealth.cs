using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ennemy
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère la vie du Gingerbread
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        #region Variables
        public float maximumHealth;
        public float health;
        public bool isAlive = true;
        #endregion

        void Start()
        {
            health = maximumHealth;
        }
        void Update()
        {
            if (health <= 0)
            {
                Death();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("IceBullet"))
            {
                health--;
            }
        }


        void Death()
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
}