using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource fxAudioSource;
    [SerializeField]
    private SoundAndMusicSO gameSoundData;

    private void OnEnable()
    {
        GameManager.Instance.OnCoinCollected += PlayCoinSound;
    }

    private void PlayCoinSound()
    {
        fxAudioSource.clip = gameSoundData.CoinSound;
        fxAudioSource.Play();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinCollected -= PlayCoinSound;
    }
}
