using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinValue;
    private void OnEnable() {
        GameManager.Instance.OnCoinCollected += UpdateText;
        UpdateText();
    }
    private void UpdateText() {
        _coinValue.text = GameManager.Instance.CoinsCollected.ToString();
    }
    private void OnDisable() {
        GameManager.Instance.OnCoinCollected -= UpdateText;
    }
}
