using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float firerate;
    public float speed;
    public GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Shoot()
    {
       GameObject bullet= Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        bullet.AddComponent<Rigidbody2D>();
        bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        yield return new WaitForSeconds(firerate);
        StartCoroutine(Shoot());
    }
}
