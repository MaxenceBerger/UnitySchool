using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;    
    
    [SerializeField]
    private float _movementForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += new Vector3(-0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector3(0.1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector3(0, 0.1f, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector3(0, -0.1f, 0);
        }

        direction.Normalize();

        _playerTransform.position += direction * _movementForce * Time.deltaTime;
    }
}
