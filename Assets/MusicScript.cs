using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField]
    private SoundAndMusicSO gameSoundData;

    [SerializeField]
    private AudioSource musicAudioSource;


    void Start()
    {
        if(gameSoundData.Level1Music != null)
        {
            musicAudioSource.clip = gameSoundData.Level1Music;
            musicAudioSource.Play();
        }
    }
}
