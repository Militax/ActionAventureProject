using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GingerbreadBehaviour : Enemy
{
    public float minimumDistance;
    private bool AttackRange = false;
    public LayerMask playerLayerMask;


    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!isAttacking)
        {
            Move();
            Attack();
        }

        
        
    }
    private void Attack()
    {
        if (AttackRange == true)
        {
            if (attackCooldown <= 0)
            {
                player.health -= 1;
                attackCooldown = initialAttackCooldown;
            }
            else
            {
                attackCooldown -= 1;
            }
        }
        

    }
    private void Move()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > minimumDistance)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * baseSpeed;
            AttackRange = false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            AttackRange = true;
        }
    }

    

    
}
