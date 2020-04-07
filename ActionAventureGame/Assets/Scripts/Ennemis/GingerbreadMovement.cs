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


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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

        void Movement()
        {
            if (canMove && !isAttacking && !isAffectedByWind)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * (moveSpeed);
            }


        }      
    }
}