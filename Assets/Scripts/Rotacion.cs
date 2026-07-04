using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotacion : MonoBehaviour
{
    public float Velocidad = 5.0f;

    private Rigidbody2D _body;
    private float _rotacion = 0.0f;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rotacion = Movimiento.Axis(Keyboard.current.aKey, Keyboard.current.dKey);
    }

    private void FixedUpdate()
    {
        float rotation = math.lerp(_body.rotation, _body.rotation + _rotacion * Velocidad, Time.fixedDeltaTime);

        _body.MoveRotation(rotation);
    }
}
