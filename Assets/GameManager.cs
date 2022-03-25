using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int _coinsCollected;
    public int CoinsCollected { get => _coinsCollected; }

    public Action OnCoinCollected;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void AddACoin()
    {
        _coinsCollected++;
        Debug.Log($"Tu as {_coinsCollected} pi�ce(s)");

        OnCoinCollected?.Invoke();
    }

}
