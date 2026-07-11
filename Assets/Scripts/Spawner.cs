using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Alien;

    [SerializeField]
    public float Intervalo = 5.0f;

    private float _timer = 0.0f;

    public void FixedUpdate()
    {
        if (_timer > 0.0f)
        {
            _timer -= Time.fixedDeltaTime;
        }
        else
        {
            _timer = Intervalo;

            CrearAlien();
        }
    }

    private void CrearAlien()
    {
        float distancia = Random.Range(20, 25);
        float angulo = Random.Range(0, 360) * Mathf.Deg2Rad;

        Vector2 pos = new Vector2(Mathf.Cos(angulo), Mathf.Sin(angulo)) * distancia;

        GameObject alien = Instantiate(Alien);
        alien.transform.position = pos;
    }
}
