using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{


    public class SwitchObject : MonoBehaviour
    {
        #region Variables
        public GameObject stateOne;
        public GameObject stateTwo;

        public bool isReversible;

        public bool stateOneActive;
        public bool stateTwoActive;
        #endregion

        void Start()
        {
            Initialisation();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //On vérifie que c'est bien la vague qui touche l'objet
            if (other.CompareTag("WindWave"))
            {
                //Si l'objet est en etat 1, on le passe en etat 2
                if (stateOneActive)
                {
                    #region To State 2
                    stateTwo.SetActive(true);
                    stateOne.SetActive(false);
                    stateOneActive = false;
                    stateTwoActive = true;
                    #endregion
                }
                //Si l'objet est en etat 2, on le passe en etat 1
                else if (stateTwo == true)
                {
                    #region To State 1
                    stateOne.SetActive(true);
                    stateTwo.SetActive(false);
                    stateOneActive = true;
                    stateTwoActive = false;
                    #endregion
                }


                //Si l'objet n'est pas reversible, on bloque tout
                if (!isReversible)
                {
                    stateOneActive = false;
                    stateTwoActive = false;
                }
            }
        }


        //Sert à initialiser certaines variable et apporte une sécurité à l'activation des phases
        void Initialisation()
        {
            if (stateOneActive)
            {
                stateTwoActive = false;
                stateOne.SetActive(true);
                stateTwo.SetActive(false);
            }
            else if (stateTwoActive)
            {
                stateOneActive = false;
                stateOne.SetActive(false);
                stateTwo.SetActive(true);
            }
        }

    }
}