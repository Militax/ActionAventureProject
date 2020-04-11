using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class catBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public float prepareTime;
    public float speed;
    public float dashTime;
    public float vulnerable;
    bool canBeDamaged;
    bool playerisIn = false;
    bool isDashing;
    bool prepare;
    bool IsCharging;
    public GameObject Player;
    Vector3 target;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerisIn = true;
            StartCoroutine(Preparing());
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerisIn = false;
    }

    IEnumerator Preparing()
    {
        if (playerisIn)
        {
            //anim de preparation à attaquer
            yield return new WaitForSeconds(prepareTime / 2);
            target = Player.transform.position;
            yield return new WaitForSeconds(prepareTime / 2);
            isDashing = true;
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
            canBeDamaged = true;
            yield return new WaitForSeconds(vulnerable);
            canBeDamaged = false;
            StartCoroutine(Preparing());
        }
        
        
    }


    

    private void Update()
    {
        Vector3 path = target - gameObject.transform.position;

        if (isDashing)
        {
            rb.velocity = path * speed;
        }
        
    }
}
