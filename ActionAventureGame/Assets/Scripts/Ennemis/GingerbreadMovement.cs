using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Ennemy
{
    public class GingerbreadMovement : EnemyValues
    {
        

        #region Variables
        private bool attackRange = false;
        public float attackDistance;
        #endregion

        void Start()
        {
            OnStart();
        }
        
        void Update()
        {
            Move();
            Attack();
        }


        void Move()
        {
            if (Vector2.Distance(transform.position, player.transform.position) > attackDistance)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * moveSpeed;
                attackRange = false;
            }
            else
            {
                rb.velocity = Vector2.zero;
                attackRange = true;
            }
        }

        void Attack()
        {
            if (attackRange == true && canAttack)
            {
                Debug.Log("Gingerbread attack !");
                StartCoroutine(AttackCoroutine());
            }
        }



        IEnumerator AttackCoroutine()
        {
            canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}