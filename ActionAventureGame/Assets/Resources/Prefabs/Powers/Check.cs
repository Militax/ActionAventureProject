using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public struct RayCheck
    {

        public Vector2 origin;
        public bool isGood;

        public RayCheck(Vector2 origin)
        {
            this.origin = origin;
            this.isGood = true;
        }
        public void SetIsGood(bool booleen)
        {
            this.isGood = booleen;
        }
    }
}