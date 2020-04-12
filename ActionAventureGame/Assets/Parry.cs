using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    Rigidbody2D rb;
    bool takedamage;
    
    // Start is called before the first frame update

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        takedamage = gameObject.GetComponent<catBehaviour>().canBeDamaged;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword")
        {
            if (takedamage)
                gameObject.GetComponent<CatHp>().currentHP -= gameObject.GetComponent<CatHp>().DamageTaken; //animation degats subis
            else
                return; //animation parade


        }
        if (collision.tag == "WindWave")
        {
            rb.velocity = Vector3.zero;
        }

    }
}
