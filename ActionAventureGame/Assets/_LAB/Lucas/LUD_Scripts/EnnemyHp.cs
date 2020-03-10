using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHp : MonoBehaviour
{
    public int HP;
 
    

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "épée")
        {
            HP -= 5;
        }
    }
}
