using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Power;

namespace Ennemy
{

    /// <summary>
    /// Louis Lefebvre
    /// 
    ///  | Mouvement de l'ennemi Gingerbread
    /// </summary>
    public class GingerbreadMovement : MonoBehaviour
    {
        #region Variables
        public PlayerMovement player;
        public float moveSpeed;
        public float aggroZone;
        public float attackDistance;
        
        Rigidbody2D rb;
        bool canMove = false;
        public bool isAttacking = false;
        #endregion


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        } 
        void Update()
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= aggroZone && !canMove)
            {
                canMove = true;
            }

            Movement();
        }

        void Movement()
        {
            if (canMove && !isAttacking)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * (moveSpeed);
            }


        }








        /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                StartCoroutine(WindEffect(other));
            }
        }


        //Temps ou l'ennemi est repoussé
        IEnumerator WindEffect(Collider2D collider)
        {
            canMove = false;
            rb.velocity = collider.GetComponent<Rigidbody2D>().velocity / windEffectSlowdown;
            yield return new WaitForSeconds(windEffectDuration);
            canMove = true;
        }
        */
    }
}