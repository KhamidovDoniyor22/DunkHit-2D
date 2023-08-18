using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForceUp;
    [SerializeField] private float _jumpForceSide;

    private Rigidbody2D _rigidBody2D;
    private Vector2 _jumpForce;
    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _rigidBody2D.velocity = Vector2.zero;
            Jump();
        }
    }
    private void Jump()
    {
        _rigidBody2D.AddForce(_jumpForce, ForceMode2D.Impulse);
    }
    public void ChangeSide(Sides side)
    {
        _jumpForce = new Vector2((int)side * _jumpForceSide, _jumpForceUp);
    }
}
