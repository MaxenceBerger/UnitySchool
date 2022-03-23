using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRB;
    [SerializeField]
    private float _movementForce = 100f;
    [SerializeField]
    private float _jumpForce = 100f;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello world!");
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("Je m'active!");
    }

    // Update is called once per frame
    private void Update()
    {
        //On traite désormais à part le mouvement vertical (en partie géré par le moteur physique)
        float horizontalMovement = 0;
        float verticalMovement = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            verticalMovement += _jumpForce;
        }
        //Plus besoin de normaliser, on pourrait utiliser une direction à 1 ou -1 en tant que multiplicateur,
        //mais c'est plus rapide de directement déterminer le mouvement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement -= _movementForce;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement += _movementForce;
        }

        //Définir directement le y de la vélocité override ce que Unity calcule avec la gravité.
        //_playerRB.velocity = movement * _movementForce;

        Vector2 newVelocity = new Vector2(horizontalMovement, _playerRB.velocity.y + verticalMovement);

        //Debug.Log($"{_playerRB.velocity.y}");
        _playerRB.velocity = newVelocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");

        if (collision.gameObject.layer == LayerMask.NameToLayer("PlatformerGround"))
        {
            Debug.Log("Player touche le sol");

        }
    }

    private void OnDisable()
    {
        Debug.Log("Je me désactive.");
    }


}
