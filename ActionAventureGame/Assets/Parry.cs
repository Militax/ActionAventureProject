using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword")
        {
            //animation
        }
        if (collision.tag == "WindWave")
        {
            rb.velocity = Vector3.zero;
        }

    }
}
