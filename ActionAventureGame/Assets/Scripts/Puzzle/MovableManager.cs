using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class MovableManager : MonoBehaviour
    {
        public bool canMove;

        private void Start()
        {
            canMove = true;
        }
    }
}