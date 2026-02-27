using TMPro;
using UnityEngine;

public class movementplayer : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float x = 0;
    public float velocidad = 500f;

    private void Start()
    {
        _transform.position = new Vector3(5f, 3.85f, 0f);
    }

    private void FixedUpdate()

    {
        _rb2D.linearVelocity = Vector2.right * velocidad;

    }









}
