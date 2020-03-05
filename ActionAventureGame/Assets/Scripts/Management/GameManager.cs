using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

namespace GameManagement
{
    /// <summary>
    /// General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        #region Player Variable
        #endregion

        #region Economic Variable and Object

        public int CoinOwned;

        #endregion





        void Awake()
        {
            MakeSingleton(true);
        }

        void Start()
        {
            GameInitialisation();
        }


        void Update()
        {

        }




        //Initialisation de la valeur des différentes variables
        void GameInitialisation()
        {
            CoinOwned = 0;
        }

    }
}