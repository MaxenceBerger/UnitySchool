using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddACoin();
        Destroy(this.gameObject);
    }
}
