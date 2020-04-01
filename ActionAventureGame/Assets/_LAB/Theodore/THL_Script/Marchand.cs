using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marchand : MonoBehaviour 
{
   bool CanEnterShop = true;

   public GameObject shopUI;


   void Update ()
   {
		if (CanEnterShop)
		{
			if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == false)
			{
				shopUI.SetActive (true);
			}
		}

		if (Input.GetButtonDown("Interaction") && shopUI.activeSelf == true)
			{
				shopUI.SetActive (false);
			}
   }


   void OnTriggerEnter2D(Collider2D other)
   {
		
   	   CanEnterShop = true;
	   Debug.Log("enter");
   }

   void OnTriggerExit2D(Collider2D other)
   {
   	   CanEnterShop = false;
	   Debug.Log("sortie");

   }
    
}
