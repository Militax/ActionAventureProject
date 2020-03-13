using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCinematic : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public int cinematicDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
            StartCoroutine(CinematicDuration());
        }
    }
    IEnumerator CinematicDuration()
    {
        yield return new WaitForSeconds(cinematicDuration);
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}
