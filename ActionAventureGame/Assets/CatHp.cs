using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHp : MonoBehaviour
{
    public int DamageTaken;
    public int currentHP;
    public int MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
            Destroy(gameObject);
    } 
}
