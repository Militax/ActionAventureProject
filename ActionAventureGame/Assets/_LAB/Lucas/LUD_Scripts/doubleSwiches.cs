using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleSwiches : MonoBehaviour
{
    bool isactive = false;
    public doubleSwiches other;
    private SpriteRenderer spr;
    //public GameObject active;
    //public GameObject inactive;
    // Start is called before the first frame update
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        isactive = (spr.color == Color.green);//ternaire  defini actiuf/ inactif selon la couleur du prefab
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (inactive.activeSelf)
    //    {
    //        isactive = false;
    //    }
    //}
    public void Switch(bool state) 
    {
        if (state)
        {
            isactive = !state;
            spr.color = (isactive ? Color.green : Color.red); // (Ternaire) si isactive = true : vert else :rouge
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            isactive = !isactive;
            spr.color = (isactive ? Color.green : Color.red); // (Ternaire) si isactive = true : vert else :rouge
            other.Switch(isactive);
        }

        //if (collision.tag == "Sword" && isactive == false)
        //{
        //    active.SetActive(true);
        //    inactive.SetActive(false);
        //    isactive = true;
        //}
        //else if (collision.tag == "Sword" && isactive == true)
        //{
        //    inactive.SetActive(true);
        //    active.SetActive(false);
        //    isactive = false;
        //}
    }
}
