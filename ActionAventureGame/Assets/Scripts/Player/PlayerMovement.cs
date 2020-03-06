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
        
        Rigidbody2D rb;
        Vector3 movement;



        void Start()
        {
            //Recuperation du rigidbody du player
            rb = GetComponent<Rigidbody2D>();
            
        }
        
        void Update()
        {
            //Les valeurs du vecteur sont celles des valeurs des axes d'input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            
            
            transform.position += movement.normalized * moveSpeed * Time.deltaTime;
        }
    }
}