using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGround;
    private float _movement;
    private PlayerInput _playerInput;
    

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        if (_rigidbody == null)
        {
            Debug.Log("Rigidbody2d не назначен в инспекторе");
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        if (_spriteRenderer == null)
        {
            Debug.Log("SpriteRenderer не назначен в инспекторе");
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (_animator == null)
        {
            Debug.Log("Animator не назначен в инспекторе");
            _animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        _playerInput.Move();
        _movement = _playerInput.movement;
        _isGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, _checkDistance, _groundLayer);
        DirectionSprite();
        Animator();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_movement * _speed, _rigidbody.linearVelocity.y);


        if (_playerInput.isJump && _isGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _playerInput.ConsumeJump();
        }
    }

    private void DirectionSprite()
    {
        if (_movement > 0)
            _spriteRenderer.flipX = true;
        else if (_movement < 0)
            _spriteRenderer.flipX = false;
    }

    private void Animator()
    {
        bool isMove = Mathf.Abs(_movement) > 0.01f;
        _animator.SetBool("isMove", isMove);
        _animator.SetBool("isGround", _isGround);
    }
}
