using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ActivationDevice : MonoBehaviour
{
    [HideInInspector]public bool HasBeenActivated = false;
    public bool IsActive = false;
    protected SpriteRenderer spr;

    protected virtual void RefreshState(bool state, string tag = null)  // demande un state et optionnelement un string
    {
        HasBeenActivated = true;
    }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
}
