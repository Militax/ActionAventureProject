using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Power;
using GameManagement;

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
        public bool canMove = false;
        public bool isAttacking = false;
        public bool isAffectedByWind = false;
        #endregion
       
        Animator animator;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        } 
        void Update()
        {
            //Dis à l'ennemi qui est le joueur
            if (player == null)
            {
                player = GameManager.Instance.player;
            }

            if (Vector2.Distance(transform.position, player.transform.position) <= aggroZone && !canMove)
            {
                canMove = true;
            }

            Movement();
            Debug.Log(canMove);
        }

        private void DetectPlayer()
        {
            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                animator.SetTrigger("Run_DL");
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                animator.SetTrigger("Run_DR");
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                animator.SetTrigger("Run_TL");
            }
            //en haut a droite
            if (xDiff > 0 && yDiff > 0)
            {
                animator.SetTrigger("Run_TR");
            }
        }

        void Movement()
        {
            if (canMove && !isAttacking && !isAffectedByWind)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * (moveSpeed);
            }


        }      
    }
}