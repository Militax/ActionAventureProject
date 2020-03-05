using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Ennemy
{
    public class EnemyValues : MonoBehaviour
    {
        #region Component
        protected Rigidbody2D rb;
        public PlayerMovement player;
        #endregion

        #region Health
        public float maximumHealth;
        public float health;
        public bool isAlive = true;
        #endregion

        #region Movement
        public float moveSpeed;
        #endregion

        #region Attack
        public float attackDamage;
        public float attackCooldown;
        public bool canAttack = true;
        public bool isAttacking = false;
        #endregion


        public void OnStart()
        {
            rb = GetComponent<Rigidbody2D>();
            health = maximumHealth;
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}