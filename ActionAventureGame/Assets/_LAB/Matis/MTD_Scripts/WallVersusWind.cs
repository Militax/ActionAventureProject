using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{
    public class WallVersusWind : MonoBehaviour
    {
        public GameObject newWavePrefab;
        public Sprite windSprite;

        void OnTriggerEnter2D(Collider2D other)
        {
            WindCut.Cut(other.transform, transform.position, newWavePrefab, windSprite);
        }
    }
}