using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pressureplatePlayer : MonoBehaviour
{
    public bool deSpawnOnLeave = true;
    private GameObject instance;
    public GameObject eventObject;
    private SpriteRenderer spr;
    public Vector3 eventPosition;
    public GameObject ActivateEvent;
    public GameObject DeActivateEvent;
    
    [Serializable] public class Combination
    {
        public string colliderTag;
        public Color active;
        public Color inactive;
    }

    public Combination[] combinations;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkActivity(collision.tag, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkActivity(collision.tag, false);
    }
    private void checkActivity(string Tag,bool active)
    {
        
        foreach (Combination item in combinations)
        {
            
            if (item.colliderTag == Tag)
            {
                if (active && eventObject && instance == null)
                {
                    instance = Instantiate(eventObject, eventPosition + transform.position, Quaternion.identity, transform);
                    iTween.PunchScale(instance, new Vector3(1, 1, 0), 0.5f);
                }
                else if (!active && instance && deSpawnOnLeave)
                    Destroy(instance);
                Debug.Log(String.Format("this: {0} vs {1}", item.colliderTag, Tag));
                spr.color = (active ? item.active : item.inactive);
                ActivateEvent.SetActive(true);
                DeActivateEvent.SetActive(false);
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (eventObject)
        {
            
            Gizmos.color = new Color(1,1,0,.2f);
            Gizmos.DrawCube(transform.position + eventPosition, new Vector3(1, 1, 0));
            Gizmos.DrawLine(transform.position , transform.position + eventPosition);
        }

    }
}
