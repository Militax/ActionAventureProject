using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Power
{

    /// <summary>
    /// Matis Duperray
    /// 
    ///  | Une prouesse technique si ca marche
    /// </summary>
    public class WindCut : MonoBehaviour
    {

        public static bool Cut(Transform victim, Vector3 _pos, GameObject newWavePrefab, Sprite windSprite)
        {
            Vector3 pos = new Vector3(_pos.x, victim.position.y, 0);
            Vector3 victimScale = victim.localScale;

            float distance = Vector3.Distance(victim.position, pos);


            if (distance >= victimScale.y/2)
            {
                return false;
            }
            

            Vector3 leftPoint = victim.position - (Vector3.right * (victimScale.y / 2));
            Vector3 rightPoint = victim.position + (Vector3.right * (victimScale.y / 2));
            Destroy(victim.gameObject);

            GameObject rightSideObj = Instantiate(newWavePrefab);
            rightSideObj.transform.position = (rightPoint + pos) / 2;
            float rightWidth = Vector3.Distance(pos, rightPoint);
            rightSideObj.transform.localScale = new Vector3(rightWidth, victimScale.y, victimScale.z);
            rightSideObj.AddComponent<SpriteRenderer>().sprite = windSprite;
            rightSideObj.AddComponent<PolygonCollider2D>().isTrigger = true;

            GameObject leftSideObj = Instantiate(newWavePrefab); ;
            leftSideObj.transform.position = (leftPoint + pos) / 2;
            float leftWidth = Vector3.Distance(pos, leftPoint);
            leftSideObj.transform.localScale = new Vector3(leftWidth, victimScale.y, victimScale.z);
            leftSideObj.AddComponent<SpriteRenderer>().sprite = windSprite;
            leftSideObj.AddComponent<PolygonCollider2D>().isTrigger = true;


            return true;
        }



    }
}