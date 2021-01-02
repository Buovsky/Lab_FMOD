using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBankLoader : MonoBehaviour
{
    [SerializeField] StudioBankLoader bankLoader;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bankLoader.Load();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bankLoader.Unload();
        }
    }
}
