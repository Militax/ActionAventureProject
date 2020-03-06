using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Matis Duperray
/// 
/// Deplacements du personnage
/// </summary>
namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        float fixedMoveSpeed;
        float baseMoveSpeed;
        Rigidbody2D rb;
        Vector3 movement;



        void Start()
        {
            //Recuperation du rigidbody du player
            rb = GetComponent<Rigidbody2D>();
            fixedMoveSpeed = moveSpeed / Mathf.Sqrt(2);
            baseMoveSpeed = moveSpeed;
        }
        
        void Update()
        {
            //Les valeurs du vecteur sont celles des valeurs des axes d'input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            //On deplace le rigidbody en fonction des valeurs etablies
            //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            //rb.velocity = (transform.position - transform.position).normalized * moveSpeed;
            if (movement.x != 0 && movement.y !=0)
            {
                moveSpeed = fixedMoveSpeed;
            }
            else
            {
                moveSpeed = baseMoveSpeed;
            }
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}