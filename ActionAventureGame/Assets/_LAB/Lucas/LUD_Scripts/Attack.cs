using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Lucas Deutschmann
/// 
/// Script attaque joueur
/// </summary>
namespace Player
{
    public class Attack : MonoBehaviour
    {
        public GameObject prefabHitbox;
        [Range(0.0f, 10.0f)]
        public float range;
        public float cooldown;
        bool isAttacking = false;
        [Range(0.0f, 10.0f)]
        public float speed;
        Vector3 direction;
        Vector3 attackPos;
        float verticalDelta;
        float horizontalDelta;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //attackPos = transform.position + Mathf.Sqrt(range) * transform.up + Mathf.Sqrt(range) * transform.right;
            //horizontalDelta = Input.GetAxisRaw("Horizontal");
            //verticalDelta = Input.GetAxisRaw("Vertical");

            //if (verticalDelta > 0.2 || horizontalDelta > 0.2 || verticalDelta < -0.2 || horizontalDelta < -0.2)
            //{
            //    //verifie que le joystick est vraiment utilisé de manière volontaire
            //    if (verticalDelta>=0 && horizontalDelta >=0)
            //    {
            //        // regarde en haut à droite
            //        attackPos = transform.position + range * transform.up + range * transform.right;
            //    }

            //}






            if (Input.GetButtonDown("Fire1"))
            {
                Attaque();
            }
        }

        void Attaque()
        {

            Instantiate(prefabHitbox, transform.position + range * transform.right, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 180));
            Attaque_Movement();
            StartCoroutine(Attack_Cooldown());
        }
        void Attaque_Movement()
        {
            transform.position += (range * transform.right)/* * Time.deltaTime * speed*/;
        }
        IEnumerator Attack_Cooldown()
        {
            isAttacking = true;
            yield return new WaitForSeconds(cooldown);
            isAttacking = false;
        }
    }

}
