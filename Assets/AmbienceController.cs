using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    [SerializeField, EventRef] string eventAudioInLab;
    [SerializeField, EventRef] string eventAudioOutLab;

    private FMOD.Studio.EventInstance musicInstanceIn;
    private FMOD.Studio.EventInstance musicInstanceOut;

    private bool isInLab = false;
    private bool wasInLab = false;

    private void Update()
    {
        Debug.Log(isInLab);
    }
    private void Awake()
    {

        Invoke("CreateMusicInstance", .1f);
        

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            isInLab = true;
            Invoke("StopOutAmbient", .5f);
            if(!wasInLab)
            {
                musicInstanceIn.start();
                musicInstanceIn.triggerCue();
                wasInLab = true;
            }
            else
            {
                musicInstanceIn.setPaused(false);
            }

        }
    }
    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            isInLab = false;
            Invoke("AmbienceOutOfLab", .03f);
        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            isInLab = true;
        }

    }

    private void CreateMusicInstance()
    {
        musicInstanceIn = RuntimeManager.CreateInstance(eventAudioInLab);
        musicInstanceOut = RuntimeManager.CreateInstance(eventAudioOutLab);
        musicInstanceOut.start();
        musicInstanceOut.triggerCue();
    }

    private void AmbienceOutOfLab()
    {
        if(!isInLab)
        {
            musicInstanceIn.setPaused(true);
            musicInstanceOut.start();
            musicInstanceOut.triggerCue();
         
        }
    }

    private void StopOutAmbient()
    {
        // I'm doing this to allow ambient to cross-fade out
        musicInstanceOut.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
