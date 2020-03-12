using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Objet qui bouge après avoir recu du vent
    /// </summary>
    public class MovableObject : MonoBehaviour
    {
        public float duration;
        public float slowdown;

        Rigidbody2D rb;
        public bool isMoving;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isMoving = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("WindWave") && !isMoving)
            {
                rb.velocity = other.GetComponent<Rigidbody2D>().velocity / slowdown;
                StartCoroutine(moveDuration());
            }
        }



        IEnumerator moveDuration()
        {
            isMoving = true;
            yield return new WaitForSeconds(duration);
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}