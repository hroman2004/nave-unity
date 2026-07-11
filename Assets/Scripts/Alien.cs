using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    public float Velocidad = 100;

    private GameObject _astronauta;
    private Rigidbody2D _body;
    private SpriteRenderer _sprite;

    void Start()
    {
        _astronauta = GameObject.FindGameObjectWithTag("Astronauta");
        _body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (_astronauta.transform.position - transform.position).normalized;

        if (_body.linearVelocity.x < 0 && !_sprite.flipX)
        {
            _sprite.flipX = true;
        }

        if (_body.linearVelocity.x > 0 && _sprite.flipX)
        {
            _sprite.flipX = false;
        }

        _body.linearVelocity = direction * Velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
