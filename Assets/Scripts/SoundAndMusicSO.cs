using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMusicData", menuName = "GameData/MusicData")]
public class SoundAndMusicSO : ScriptableObject
{
    [Header("Music")]

    [SerializeField]
    private AudioClip level1Music;

    [Header("Sound")]

    [SerializeField]
    private AudioClip coinSound;

    public AudioClip Level1Music { get => level1Music; }
    public AudioClip CoinSound { get => coinSound; }
}
