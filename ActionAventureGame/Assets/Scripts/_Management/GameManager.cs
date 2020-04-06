﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;
using Player;

namespace GameManagement
{
    /// <summary>
    /// General management of the game.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        #region Player Variable

        public PlayerMovement player;
        public bool playerCanMove;

        #region Health
        public int DeathCounter;
        public int playerHealth;
        public int playerHealthMax;
        #endregion
        #region Power
        public int powerState;
        /*
        1.WindWave
        2.FrozenWave
        3.PowerWave
        */
        #endregion
        #region Damages
        public int swordDamage;
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

            playerCanMove = true;

            playerHealth = playerHealthMax;
            powerState = 1;

            swordDamage = 1;

            #endregion

            #region Economic

            CoinOwned = 0;

            #endregion
        }

    }
}