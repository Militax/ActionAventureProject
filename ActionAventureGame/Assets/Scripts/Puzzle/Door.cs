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
    public class Door : MonoBehaviour
    {
        public ActivationDevice[] linkedInput;
        public GameObject openState;
        public GameObject closeState;
        
       
        void Update()
        {
            bool state = false;
            if (linkedInput.Length == 0)
                return;
            foreach (ActivationDevice item in linkedInput)
            {
                if (!item.IsActive)
                    state = true;
            }
            closeState.SetActive(state);
            openState.SetActive(!state);

        }
        
         
        
    }
}