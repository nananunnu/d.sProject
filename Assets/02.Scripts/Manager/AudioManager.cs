using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource aS;

    public AudioClip select_Audio;
    public AudioClip Stage1_Audio;
    public AudioClip start_Audio;

    void Start()
    {

    }

    void Update()
    {
        Audio();
    }

    public void Audio()
    {
        //if(DataManager.instance.Scene == 0)
        //{
        //    aS.clip = start_Audio;
        //}
        //else if(DataManager.instance.Scene== 1)
        //{
        //    aS.clip = select_Audio;
        //}
        //else if(DataManager.instance.Scene == 2)
        //{
        //    aS.clip = Stage1_Audio;
        //}

        aS.Play();
    }
}
