using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class ShopInteraction : MonoBehaviour 
{
	

	// achat de 3 types de bottes
	public void bottesState()
	{

		if(GameManager.Instance.bottesState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 50)

			{
				Debug.Log("achat des bottes type 1");
				GameManager.Instance.bottesState = 1;
				GameManager.Instance.CoinOwned -= 50;
			}
	

		}
		else if (GameManager.Instance.bottesState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 100)
			{
				Debug.Log("achat des bottes type 2");
				GameManager.Instance.bottesState = 2;
			}
		}
	}

	//achat d'amélioration de la bourse 
	public void coinState()
	{

		if(GameManager.Instance.coinState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 50)

			{
				Debug.Log("achat de la bourse type 1");
				GameManager.Instance.coinState = 1;
				//GameManager.Instance.CoinOwned -= 50;
			}
	

		}
		else if (GameManager.Instance.coinState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 100)
			{
				Debug.Log("achat la bourse type 2");
				GameManager.Instance.coinState = 2;
			}
			
		}
		else if (GameManager.Instance.coinState == 2)
		{	
			if(GameManager.Instance.CoinOwned >= 200)
			{
				Debug.Log("achat la bourse type 3");
				GameManager.Instance.coinState = 3;
			}
		
		}



	}

	// Achat des emplacement pour les coeurs
	 public void heartState()
	{

		if(GameManager.Instance.heartState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 50)

			{
				Debug.Log("achat du coeur type 1");
				GameManager.Instance.heartState = 1;
				//GameManager.Instance.CoinOwned -= 50;
			}
	

		}
		else if (GameManager.Instance.heartState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 100)
			{
				Debug.Log("achat du coeur type 2");
				GameManager.Instance.heartState = 2;
			}
			
		}
		else if (GameManager.Instance.heartState == 2)
		{	
			if(GameManager.Instance.CoinOwned >= 200)
			{
				Debug.Log("achat du coeur type 3");
				GameManager.Instance.heartState = 3;
			}
		
		}
	}
}




	
  

