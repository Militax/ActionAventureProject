using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Ennemy
{

    /// <summary>
    /// Louis Lefebvre
    /// 
    ///  | Gère l'attaque
    /// </summary>
    public class GingerbreadAttack : MonoBehaviour
    {
        #region Variables
        private int damage;
        public int Damage { set { damage = value; } }
        private bool canAttack = false;
        private Collider2D myCollider;
        private Collider2D player;
        #endregion

        private void Awake()
        {
            myCollider = gameObject.GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            myCollider.enabled = true;
            canAttack = true;
            if (player)
            {
                OnTriggerStay2D(player);
            }
            StartCoroutine(Disapear());
        }

        private void OnTriggerStay2D(Collider2D other)
        {

            if (other.tag != "Player")
            {
                return; 
            }
            player = other;
            if (canAttack)
            {
                Debug.Log("Attack !");
                GameManager.Instance.playerHealth -= damage;
                canAttack = false;
            }

        }




        IEnumerator Disapear()
        {
            //Debug.Log("will desapear");
            yield return new WaitForSeconds(1f);
            //Debug.Log("desapear");
            myCollider.enabled = false;
            gameObject.SetActive(false);
        }


    }
}