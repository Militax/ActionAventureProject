﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

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
        Vector2 movement;



        void Start()
        {
            //Recuperation du rigidbody du player
            rb = GetComponent<Rigidbody2D>();
            GameManager.Instance.player = this;
        }

        void Update()
        {
            //Les valeurs du vecteur sont celles des valeurs des axes d'input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {

            if (GameManager.Instance.playerCanMove)
            {
                rb.velocity = movement.normalized * (moveSpeed * 50) * Time.deltaTime;
            }
        }
    }
}