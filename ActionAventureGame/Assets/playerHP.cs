using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public float BaseHP;
    public float CurrentHP;
    void Start()
    {
        CurrentHP = BaseHP;
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
        CurrentHP -= 10;
    }
    private void Update()
    {
        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
