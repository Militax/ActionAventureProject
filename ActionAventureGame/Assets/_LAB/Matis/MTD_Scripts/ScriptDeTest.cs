using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Game
{
    

    public class ScriptDeTest : MonoBehaviour
    {
        public List<Vector2> origineList;
        private List<RayCheck> checkList;


        private void Start()
        {
            checkList = new List<RayCheck>(); 

            foreach (var item in origineList)
            {
                checkList.Add(new RayCheck(item));
            }
        }

        private void Update()
        {
            foreach (var item in checkList)
            {
                if (item.isGood)
                {
                    var _ray = Physics2D.Raycast(transform.position, Vector2.right, 2);

                    if (_ray.collider)
                    {
                        item.SetIsGood(false);
                    }
                }
            }
        }

    }
}
