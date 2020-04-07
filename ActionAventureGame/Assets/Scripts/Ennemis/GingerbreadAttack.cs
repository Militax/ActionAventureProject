using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameManagement;

namespace Ennemy
{

    /// <summary>
    /// Louis Lefebvre
    /// 
    ///  | Gère l'attaque du Gingerbread
    /// </summary>
    public class GingerbreadAttack : MonoBehaviour
    {
        enum AttackDirection { NorthWest, NorthEast, SouthWest, SouthEast }

        #region Variables
        public PlayerMovement player;
        public float attackCooldown;
        public int damage;

        #region Colliders
        public GingerbreadAttackZone NWcollider;
        public GingerbreadAttackZone NEcollider; 
        public GingerbreadAttackZone SWcollider;
        public GingerbreadAttackZone SEcollider;
        #endregion

        float attackRange;
        bool isInAttackRange;
        bool canAttack = true;
        Rigidbody2D rb;
        AttackDirection direction;
        #endregion


        void Start()
        {
            attackRange = GetComponent<GingerbreadMovement>().attackDistance;
            rb = GetComponent<Rigidbody2D>();
            
        }
        void Update()
        {
            //Dis à l'ennemi qui est le joueur
            if (player == null)
            {
                player = GameManager.Instance.player;
            }

            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
            {
                DetectPlayer();
                SelectAttackCollider();
            }
        }

        private void DetectPlayer()
        {
            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                direction = AttackDirection.SouthWest;
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                direction = AttackDirection.SouthEast;
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                direction = AttackDirection.NorthWest;
            }
            //en haut a droite
            if (xDiff > 0 && yDiff > 0)
            {
                direction = AttackDirection.NorthEast;
            }
        }
        private void SelectAttackCollider()
        {
            if (canAttack)
            {
                StartCoroutine(Attack());
            }

        }


        //Gère l'attaque et les différents timings associés
        IEnumerator Attack()
        {
            rb.velocity = Vector2.zero;
            canAttack = false;//Empêche l'ennemi d'attaquer
            GetComponent<GingerbreadMovement>().isAttacking = true;//Empêche l'ennemi de bouger
            yield return new WaitForSeconds(0.5f);//Temps avant l'attaque (Animation avant l'attaque)

            switch (direction)
            {
                //ici on set active les colliders d'attaque correspondant a la bonne position relative du joueur
                case AttackDirection.NorthEast:
                    {
                        NEcollider.attackIsAsked = true;
                        break;
                    }
                case AttackDirection.NorthWest:
                    {
                        NWcollider.attackIsAsked = true;
                        break;
                    }
                case AttackDirection.SouthEast:
                    {
                        SEcollider.attackIsAsked = true;
                        break;
                    }
                case AttackDirection.SouthWest:
                    {
                        SWcollider.attackIsAsked = true;
                        break;
                    }
                default: { break; }
            }

            yield return new WaitForSeconds(attackCooldown + NEcollider.GetComponent<GingerbreadAttackZone>().duration);//Cooldown de l'attaque + la durée de l'attaque
            canAttack = true;//L'ennemi peut de nouveau frapper
            GetComponent<GingerbreadMovement>().isAttacking = false;//l'ennemi peut de nouveau bouger
        }
    }
}