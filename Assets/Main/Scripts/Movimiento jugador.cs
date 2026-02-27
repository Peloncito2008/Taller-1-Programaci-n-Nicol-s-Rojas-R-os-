using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Movimientojugador : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float x = -10;
    public float velocidad = 8f;
    public float fuerzaImpulso = 200f;

    [Header("Random en caída")]
    [SerializeField] private float minVelCaida = -8f;
    [SerializeField] private float maxVelCaida = 8f;

    private bool haParado = false;
    private float velCaidaHorizontal;

    private void Start()
    {
        _rb2d.AddForce(Vector2.right * fuerzaImpulso, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (!haParado)
        {
            if (_rb2d.position.x < x * -1)
            {
                // Mueve solo horizontal → gravedad acumula en Y naturalmente
                _rb2d.linearVelocity = new Vector2(velocidad, _rb2d.linearVelocity.y);
            }
            else
            {
                haParado = true;
                velCaidaHorizontal = Random.Range(minVelCaida, maxVelCaida);
                // Aplica el random SOLO en X, deja Y intacta (gravedad actúa)
                _rb2d.linearVelocity = new Vector2(velCaidaHorizontal, _rb2d.linearVelocity.y);
            }
        }
        // Después de parar: NO toques más la velocity → gravedad funciona sola
        // (si quieres mantener el random en X para siempre, quita este if y deja el else arriba)
    }
}