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
        Vector2 WaveMovement;

        void OnEnable()
        {
            rb = GetComponent<Rigidbody2D>();
            WaveMovement.x = 1;
            WaveMovement.y = 0;
            StartCoroutine(PowerDuration());
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + WaveMovement * power * Time.fixedDeltaTime);
        }

        IEnumerator PowerDuration()
        {
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
        }



    }
}