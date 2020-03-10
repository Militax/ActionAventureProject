using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère le mouvement de l'objet en fonction de la provenance du vent.
    /// </summary>
    public class MovableCollider : MonoBehaviour
    {
        public string position;
        public float power;
        public float duration;

        Vector2 moveDirection;
        Rigidbody2D boxRB;


        void Start()
        {
            moveDirection.x = 0;
            moveDirection.y = 0;

            boxRB = GetComponentInParent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("WindWave") && GetComponentInParent<MovableManager>().canMove)
            {

                switch (position)
                {
                    case ("TOP"):
                        moveDirection.y = (-1);
                        boxRB.velocity = moveDirection * (power * 100) * Time.fixedDeltaTime;
                        StartCoroutine(DeplacementDuration());
                        break;

                    case ("DOWN"):
                        moveDirection.y = 1;
                        boxRB.velocity = moveDirection * (power * 100) * Time.fixedDeltaTime;
                        StartCoroutine(DeplacementDuration());
                        break;

                    case ("LEFT"):
                        moveDirection.x = 1;
                        boxRB.velocity = moveDirection * (power * 100) * Time.fixedDeltaTime;
                        StartCoroutine(DeplacementDuration());
                        break;

                    case ("RIGHT"):
                        moveDirection.x = (-1);
                        boxRB.velocity = moveDirection * (power * 100) * Time.fixedDeltaTime;
                        StartCoroutine(DeplacementDuration());
                        break;
                }
            }
        }

        IEnumerator DeplacementDuration()
        {
            GetComponentInParent<MovableManager>().canMove = false;
            yield return new WaitForSeconds(duration);
            boxRB.velocity = Vector2.zero;
            GetComponentInParent<MovableManager>().canMove = true;
        }

    }
}