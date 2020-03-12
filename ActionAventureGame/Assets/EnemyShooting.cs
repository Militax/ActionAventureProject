using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject EnnemyShot;
    public GameObject Player;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - gameObject.transform.position;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player.tag)
        {
            Shooting();
        }
    }
    void Shooting()
    {
        Instantiate(EnnemyShot, direction, Quaternion.Euler(transform.rotation.eulerAngles));
    }

}
