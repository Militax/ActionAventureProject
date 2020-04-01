using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class ShopInteraction : MonoBehaviour 
{

	public void bottesState()
	{
		if(GameManager.Instance.bottesState == 0)
		{
			if(GameManager.Instance.CoinOwned >= 50)
			{
				GameManager.Instance.bottesState = 1;
			}
	

		}
		else if (GameManager.Instance.bottesState == 1)
		{
			if(GameManager.Instance.CoinOwned >= 100)
			{
				GameManager.Instance.bottesState = 2;
			}
			
		}
		else if (GameManager.Instance.bottesState == 2)
		{	
			if(GameManager.Instance.CoinOwned >= 200)
			{
				GameManager.Instance.bottesState = 3;
			}
		
		}



	}
  
}
