using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureplatePlayer : MonoBehaviour
{
    bool isactive;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {

            spr.color = Color.yellow;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            spr.color = Color.magenta;
        }
    }
}
