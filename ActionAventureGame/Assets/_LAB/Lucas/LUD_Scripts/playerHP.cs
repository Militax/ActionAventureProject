using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;


namespace Player
{
    public class playerHP : MonoBehaviour
    {
        
        public GameObject respawnPoint;
        public GameObject DeathState;
        void Start()
        {

            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                TakeDamage();
            }
        }
        void TakeDamage()
        {
            GameManager.Instance.playerHealth -= 10;
        }
        private void Update()
        {
            if (GameManager.Instance.playerHealth <= 0)
            {
                Instantiate(DeathState, transform.position, Quaternion.identity);
                gameObject.transform.position = respawnPoint.transform.position;
                GameManager.Instance.DeathCounter += 1;
                GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
            }
        }
    }
}

