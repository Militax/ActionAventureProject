using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class ShopPrix : MonoBehaviour
{
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;

	void Update ()
	{
		if (GameManager.Instance.bottesState == 0)
		{
			text1.SetActive (true);
			text2.SetActive (false);
			text3.SetActive (false);
		}
		else if (GameManager.Instance.bottesState == 1)
		{
			text1.SetActive (false);
			text2.SetActive (true);
			text3.SetActive (false);
		}
		else if (GameManager.Instance.bottesState == 2)
		{
			text1.SetActive (false);
			text2.SetActive (false);
			text3.SetActive (true);
		}
	}










}
