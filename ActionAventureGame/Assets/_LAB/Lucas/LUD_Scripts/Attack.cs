using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject prefabHitbox;
    [Range(0.0f, 10.0f)]
    public float range;
    //[Range(0.0f, 10.0f)]
    //public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Attaque();
        }
    }

    void Attaque()
    {
        if (true)
        {

        }
        Instantiate(prefabHitbox, transform.position + range *transform.right, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 180));
        Attaque_Movement();
    }
    void Attaque_Movement()
    {
        //transform.position += transform.right * Time.deltaTime * speed;
    }
}
