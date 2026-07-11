using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Movimiento : MonoBehaviour
{
    [SerializeField]
    public float Velocidad = 5.0f;

    private Rigidbody2D _body;
    private Vector2 _movimiento = Vector2.zero;
    
    public void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        _movimiento.x = Axis(Keyboard.current.dKey, Keyboard.current.aKey);
        _movimiento.y = Axis(Keyboard.current.wKey, Keyboard.current.sKey);
    }

    public void FixedUpdate()
    {
        _body.linearVelocity = _movimiento.normalized * Velocidad;
    }

    public static float Axis(KeyControl positive, KeyControl negative)
    {
        float posValue = positive.isPressed ? 1.0f : 0.0f;
        float negValue = negative.isPressed ? 1.0f : 0.0f;

        return posValue - negValue;
    }
}
