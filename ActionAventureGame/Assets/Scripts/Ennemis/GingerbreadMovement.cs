using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Power;

namespace Ennemy
{


    public enum AttackDirection
    {
        NorthWest, NorthEast, SouthWest, SouthEast
    }

    /// <summary>
    /// Louis Lefebvre
    /// 
    /// Mouvement de l'ennemi Gingerbread
    /// </summary>
    public class GingerbreadMovement : EnemyValues
    {


        #region Variables
        private bool isInAttackRange = false;
        public float minimumDistance;

        #region attaque
        private bool canAttack = true;
        private AttackDirection attackDirection;
        [SerializeField] private GameObject NE, NW, SE, SW;
        bool canMove = true;
        #endregion

        public float windEffectDuration;
        public float windEffectSlowdown;

        #endregion

        void Start()
        {
            OnStart();
            Initialisation();
        } 
        void Update()
        {
            if(canMove)
            {
                Move();
            }
            DetectPlayer();
            Attack();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave"))
            {
                StartCoroutine(WindEffect(other));
            }
        }


        void Initialisation()
        {
            //on set off les prefabs des colliders d'attaque
            NE.SetActive(false);
            NW.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(false);
            //on set les dommages des prefabs des colliders d'attaque
            NE.GetComponent<GingerbreadAttack>().Damage = attackDamage;
            NW.GetComponent<GingerbreadAttack>().Damage = attackDamage;
            SE.GetComponent<GingerbreadAttack>().Damage = attackDamage;
            SW.GetComponent<GingerbreadAttack>().Damage = attackDamage;
        }

        #region Fonctions
        private void DetectPlayer()
        {
            // on regarde ou est le joueur par rapport au gingerbread
            float xDiff = player.transform.position.x - transform.position.x;
            float yDiff = player.transform.position.y - transform.position.y;
            //en bas a gauche 
            if (xDiff < 0 && yDiff < 0)
            {
                attackDirection = AttackDirection.SouthWest;
            }
            //en bas a droite
            if (xDiff > 0 && yDiff < 0)
            {
                attackDirection = AttackDirection.SouthEast;
            }
            //en haut a gauche
            if (xDiff < 0 && yDiff > 0)
            {
                attackDirection = AttackDirection.NorthWest;
            }
            //en haut a droite
            if (xDiff > 0 && yDiff > 0)
            {
                attackDirection = AttackDirection.NorthEast;
            }
        }
        void Move()
        {
            if (Vector2.Distance(transform.position, player.transform.position) > minimumDistance)
            {
                rb.velocity = (player.transform.position - transform.position).normalized * (moveSpeed);
                isInAttackRange = false;
            }
            else
            {
                rb.velocity = Vector2.zero;
                isInAttackRange = true;
            }
        }
        private void Attack()
        {
            if (isInAttackRange == true && canAttack == true)
            {
                switch (attackDirection)
                {
                    //ici on set active les colliders d'attque correspondant a la bonne position relative du joueur
                    case AttackDirection.NorthEast:
                        {
                            NE.SetActive(true);
                            //Debug.Log("NE");
                            break;
                        }
                    case AttackDirection.NorthWest:
                        {
                            NW.SetActive(true);
                            //Debug.Log("NW");
                            break;
                        }
                    case AttackDirection.SouthEast:
                        {
                            SE.SetActive(true);
                            //Debug.Log("SE");
                            break;
                        }
                    case AttackDirection.SouthWest:
                        {
                            SW.SetActive(true);
                            //Debug.Log("SW");
                            break;
                        }
                    default: { break; }
                }
                canAttack = false;

                StartCoroutine(CooldownAttack());
            }

        }

        #endregion


        //Temps ou l'ennemi est repoussé
        IEnumerator WindEffect(Collider2D collider)
        {
            Debug.Log("Debut");
            canMove = false;
            rb.velocity = collider.GetComponent<Rigidbody2D>().velocity / windEffectSlowdown;
            yield return new WaitForSeconds(windEffectDuration);
            canMove = true;
            Debug.Log("Fin");
        }
        //coroutine de cooldown
        IEnumerator CooldownAttack()
        {
            //Debug.Log("willAttack");
            yield return new WaitForSecondsRealtime(3f);//attackCooldown
            canAttack = true;
            //Debug.Log("AttackCouldown");
        }
    }
}