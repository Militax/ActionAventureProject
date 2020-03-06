using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{
    public class WindPower : MonoBehaviour
    {
        public float duration = 1f;
        public float power = 1f;

        Rigidbody2D rb;
        public Vector2 WaveDirection; //Direction du tir

        void OnEnable()
        {//Quand l'objet s'instanci
            rb = GetComponent<Rigidbody2D>();
            WaveDirection.x = 0;
            WaveDirection.y = 0;
            StartCoroutine(PowerDuration());
        }

        private void Update()
        {
            //Fait avancer la vague en fonction de (DIRECTION * FORCE)
            rb.velocity = WaveDirection * (power*100) * Time.fixedDeltaTime;
        }


        //Durée de vie de la vague
        IEnumerator PowerDuration()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }



    }
}