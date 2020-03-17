using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

namespace Ennemy
{
    public class IceBullet : MonoBehaviour
    {
        #region Variables
        public Transform player;
        public float power;
        public int damage;

        Rigidbody2D rb;
        Vector2 FireDirection = new Vector2(0, 0); //Direction du tir
        #endregion

        void Start()
        {
            FireDirection = player.position - gameObject.transform.position;
            rb = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            //Fait avancer la balle en fonction de (DIRECTION * FORCE)
            rb.velocity = FireDirection * (power * 100) * Time.fixedDeltaTime;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.playerHealth -= damage;
                Destroy(gameObject);
            }
        }
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}