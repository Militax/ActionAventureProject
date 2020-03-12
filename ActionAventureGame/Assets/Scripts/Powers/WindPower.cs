﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{
    public class WindPower : MonoBehaviour
    {
        public float duration;
        public float power;

        Rigidbody2D rb;
        public Vector2 WaveDirection = new Vector2(0,0); //Direction du tir

        void Start()
        {//Quand l'objet s'instanci
            rb = GetComponent<Rigidbody2D>();       
            StartCoroutine(PowerDuration());
        }

        private void Update()
        {            
            //Fait avancer la vague en fonction de (DIRECTION * FORCE)
            rb.velocity = WaveDirection * (power*100) * Time.fixedDeltaTime;
            Debug.Log("Test");
            Debug.Log(WaveDirection);
        }


        //Durée de vie de la vague
        IEnumerator PowerDuration()
        {
            //yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }

    }
}