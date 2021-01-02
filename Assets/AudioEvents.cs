using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public static AudioEvents soundEvent;

    private void Awake()
    {
        soundEvent = this;
    }

    public event Action onOutpostEnter;
    public event Action onOutpostExit;

    public void OutpostEnter()
    {
        onOutpostEnter?.Invoke();
    }

    public void OutpostExit()
    {
        onOutpostExit?.Invoke();
    }

}
