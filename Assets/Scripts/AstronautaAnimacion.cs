using UnityEngine;
using UnityEngine.InputSystem;

public class AstronautaAnimacion : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;
    private SpriteRenderer _armaSprite;
    private Transform _holderTransform;
    private Rigidbody2D _body;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _body = GetComponent<Rigidbody2D>();

        _holderTransform = transform.Find("ArmaHolder").transform;
        _armaSprite = _holderTransform.GetComponentInChildren<SpriteRenderer>();
    }

    public void Update()
    {
        _animator.SetBool("isWalking", _body.linearVelocity.magnitude > 0.1f);

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        Vector2 lookDirection = (mouseWorldPos - _body.position).normalized;

        if (lookDirection.x < 0 && !_sprite.flipX)
        {
            _sprite.flipX = true;
            _armaSprite.flipY = true;
        }

        if (lookDirection.x > 0 && _sprite.flipX)
        {
            _sprite.flipX = false;
            _armaSprite.flipY = false;
        }

        _holderTransform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg);
    }
}
