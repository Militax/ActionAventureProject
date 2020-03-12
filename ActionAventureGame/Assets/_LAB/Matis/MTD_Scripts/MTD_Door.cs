using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Gère l'ouverture de la porte
    /// </summary>
    public class MTD_Door : MonoBehaviour
    {
        public GameObject linkedInput;
        public GameObject openState;
        public GameObject closeState;
        
       
        void Update()
        {
            if (linkedInput.activeSelf)
            {
                closeState.SetActive(false);
                openState.SetActive(true);
            }
            else if (!linkedInput.activeSelf)
            {
                openState.SetActive(false);
                closeState.SetActive(true);
            }
        }
        
        
        
    }
}