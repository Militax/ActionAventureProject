using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Matis Duperray
/// 
/// Script qui invoque les pouvoirs
/// </summary>
namespace Player
{
    public class PlayerPowers : MonoBehaviour
    {
        public GameObject WindPowerPrefab;

        
        void Start()
        {
            
        }
        
        void Update()
        {
            InstantiateWindPower();
        }
        
        
        void InstantiateWindPower()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))//Clique droit
            {
                GameObject WindWave = Instantiate(WindPowerPrefab, transform.position, transform.rotation);
            }
        }
    }
}