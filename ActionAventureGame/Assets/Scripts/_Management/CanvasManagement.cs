using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace GameManagement
{
    /// <summary>
    /// Gère l'affichage en jeu des informations
    /// </summary>
    public class CanvasManagement : MonoBehaviour
    {
        #region Economic
        public TextMeshProUGUI CoinCount;
        #endregion

        void Start()
        {
            
        }
        
        void Update()
        {
            EconomicCanvas();
        }



        //Gère l'affichage des valeurs relatives à l'économie
        void EconomicCanvas()
        {
            CoinCount.text = GameManager.Instance.CoinOwned.ToString();
        }
    }
}