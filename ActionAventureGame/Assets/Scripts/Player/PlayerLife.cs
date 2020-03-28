using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;
public class PlayerLife : MonoBehaviour {
	
	//public int health;
	//public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	void Update(){

		if(GameManager.Instance.playerHealth > GameManager.Instance.playerHealthMax){
			GameManager.Instance.playerHealth = GameManager.Instance.playerHealthMax;
		}
	
		for (int i = 0; i < hearts.Length; i++) {
		
		if(i < GameManager.Instance.playerHealth){
			hearts[i].sprite = fullHeart;
		}else{
			hearts[i].sprite = emptyHeart;
		}

		if(i < GameManager.Instance.playerHealthMax){
			hearts[i].enabled = true;
		} else {
			hearts[i].enabled = false;
		}

		}
	}


}
