using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Ennemy
{
    public class PowerEnnemyInteraction : MonoBehaviour
    {

        #region Variables
        public float windEffectSlowdown;
        public float windEffectDuration;

        string ennemyType;
        Rigidbody2D rb;
        #endregion
        

        void Start()
        {
            ennemyType = this.GetComponent<EnemyHealth>().ennemyType;
            rb = GetComponent<Rigidbody2D>();
        }
        
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
            switch (ennemyType)
            {

                case ("Gingerbread")://Sur le gingerbread

                    GetComponent<GingerbreadMovement>().canMove = false;//Empeche l'ennemi de bouger
                    rb.velocity = collider.GetComponent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                    yield return new WaitForSeconds(windEffectDuration);
                    GetComponent<GingerbreadMovement>().canMove = true;//L'ennemi peut rebouger

                    break;


                case ("Chat")://Sur le chat
                    break;


                case ("Snowman")://Sur le SnowMan

                    if (GameManager.Instance.powerState == 3)
                    {
                        rb.velocity = collider.GetComponent<Rigidbody2D>().velocity / windEffectSlowdown;//Fait reculer l'ennemi
                        yield return new WaitForSeconds(windEffectDuration);
                        rb.velocity = Vector2.zero;
                    }

                    break;

            }
        }
    }
}