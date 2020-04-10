﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

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
        public string ennemyType;
        /*
        1.Gingerbread
        2.Snowman
        3.Chat
         */

        public float health;
        public float maximumHealth;
        public float safeTime;
        public bool isAlive = true;

        bool canTakeDamage = true;
        #endregion
        Animator animator;
        void Start()
        {
            health = maximumHealth;
            animator = gameObject.GetComponent<Animator>();
        }
        void Update()
        {
            if (health <= 0)
            {
                Death();
                animator.SetTrigger("Death");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Sword") && ennemyType != ("Snowman") && canTakeDamage)
            {
                health -= GameManager.Instance.swordDamage;
                StartCoroutine(SafeCooldown());
            }
            if (other.CompareTag("IceBullet") && canTakeDamage)
            {
                if(other.GetComponent<IceBullet>().isOut)//La balle est partie du Snowman
                {
                    Debug.Log("Hit");
                    health--;
                    animator.SetTrigger("Degat");
                    Destroy(other.gameObject);
                    StartCoroutine(SafeCooldown());
                }
            }
        }


        void Death()
        {
            isAlive = false;
            Destroy(gameObject);
        }
        IEnumerator SafeCooldown()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(safeTime);
            canTakeDamage = true;
        }
    }
}