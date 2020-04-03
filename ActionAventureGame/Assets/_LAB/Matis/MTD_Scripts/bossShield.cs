using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class bossShield : MonoBehaviour
    {
        int shieldLife = 4;

        void Update()
        {
            if (shieldLife <= 0)
            {
                Destroy(gameObject);
                GetComponentInParent<BossComportement>().isStunt = true;
                GetComponentInParent<BossComportement>().shieldActive = false;
            }
        }
    }
}