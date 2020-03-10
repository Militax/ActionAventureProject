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

        #region Health
        public int playerHealth;
        public int playerHealthMax;
        #endregion

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




        //Initialisation de la valeur des différentes variables
        void GameInitialisation()
        {
            #region Player
            playerHealth = playerHealthMax;
            #endregion

            #region Economic
            CoinOwned = 0;
            #endregion
        }

    }
}