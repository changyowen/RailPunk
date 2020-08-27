using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PauseSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        PauseSound = Resources.Load<AudioClip>("PauseSoundStretch2");
    }

    //sound effect function for pause & unpause
    public static void playPauseSound()
    {
        audioSrc.PlayOneShot(PauseSound);
    }
}
