using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    /// <summary>
    /// Lucas Deutschmann
    /// 
    ///  | Colliders d'attaque
    /// </summary>
    public class AttackColliders : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(deactivate());
        }

        IEnumerator deactivate()
        {
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}