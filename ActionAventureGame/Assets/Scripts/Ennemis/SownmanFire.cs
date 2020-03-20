﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ennemy
{
    public class SownmanFire : MonoBehaviour
    {

        #region Variables
        public Transform player;
        public GameObject iceBulletPrefab;

        public float cooldown;

        bool isInFireZone = false;
        bool canShoot = true;

        #endregion

        void Update()
        {
            if (isInFireZone && canShoot)
            {
                Shooting();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInFireZone = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isInFireZone = false;
            }
        }


        void Shooting()
        {
            GameObject bullet = Instantiate(iceBulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<IceBullet>().player = player;
            StartCoroutine(SnowmanFireCooldown());
        }
        IEnumerator SnowmanFireCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
    }
}