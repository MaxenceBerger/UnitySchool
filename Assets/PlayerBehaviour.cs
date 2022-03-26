using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRB;

    [SerializeField]
    private float _movementForce = 100f;

    [SerializeField]
    private float _jumpForce = 100f;

    [SerializeField]
    private int _totalRemainingJumps = 2;

    [SerializeField]
    private GameObject _canvasPlayerKilled;

    [SerializeField]
    private GameObject _canvasPlayerWon;

    [SerializeField] 
    private Animator _animator;

    private PlayerState _currentState;
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private int _currentRemainingJumps;

    private void Start()
    {
        _currentRemainingJumps = _totalRemainingJumps;
        _canvasPlayerKilled.GetComponent<Canvas>();
        _canvasPlayerWon.GetComponent<Canvas>();
        _canvasPlayerKilled.SetActive(false);
        _canvasPlayerWon.SetActive(false);
    }

    private void Update()
    {
        float horizontalMovement = 0;
        float verticalMovement = 0;

        _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetKeyDown(KeyCode.UpArrow) && (_currentRemainingJumps > 0))
        {
            verticalMovement += _jumpForce;
            _currentState = PlayerState.IsJumping;
            _currentRemainingJumps--;
            _animator.SetFloat("Jump", Mathf.Abs(verticalMovement));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement -= _movementForce;
            Flip(horizontalMovement);
            _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement += _movementForce;
            Flip(horizontalMovement);
            _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        }

        Vector2 newVelocity = new Vector2(horizontalMovement, _playerRB.velocity.y + verticalMovement);
        _playerRB.velocity = newVelocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float resetVerticalMovement = 0;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _currentState = PlayerState.IsGrounded;
            _currentRemainingJumps = _totalRemainingJumps;
            _animator.SetFloat("Jump", resetVerticalMovement);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("GroundKillPlayer"))
        {
            gameObject.SetActive(false);
            _canvasPlayerKilled.GetComponent<Canvas>();
            _canvasPlayerKilled.SetActive(true);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("WonPlayer"))
        {
            gameObject.SetActive(false);
            _canvasPlayerWon.GetComponent<Canvas>();
            _canvasPlayerWon.SetActive(true);
        }
    }
    private void Flip(float _velocityPlayer)
    {
        if (_velocityPlayer > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_velocityPlayer < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private enum PlayerState
    {
        IsGrounded,
        IsJumping
    }
}
