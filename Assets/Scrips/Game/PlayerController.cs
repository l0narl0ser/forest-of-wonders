using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    private float _direction = 0f;
    private float _sprintSpeed = 4f;
    private float _walkSpeed = 2f;
    private float _jumpHeight = 7f;


    private void Awake()
    {
        InputEvent.OnPlayerAttack += OnPlayerAttacked;
        InputEvent.OnPlayerInteract += OnPlayerInteracted;
        InputEvent.OnPlayerMove += OnPlayerMoved;
        InputEvent.OnPlayerJump += OnPlayerJumped;
        InputEvent.OnPlayerSprint += OnPlayerSprinted;
    }

    private void OnPlayerSprinted()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _rigidBody.velocity = new Vector3(_direction * _sprintSpeed, _rigidBody.velocity.y);
        ;
    }

    private void OnPlayerJumped()
    {
        if (IsGrounded()) _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _jumpHeight);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, .1f);
    }

    private void OnPlayerMoved()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _rigidBody.velocity = new Vector3(_direction * _walkSpeed, _rigidBody.velocity.y, 0);
    }

    private void OnPlayerInteracted()
    {
        throw new NotImplementedException();
    }

    private void OnPlayerAttacked()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        InputEvent.OnPlayerAttack -= OnPlayerAttacked;
        InputEvent.OnPlayerInteract -= OnPlayerInteracted;
        InputEvent.OnPlayerMove -= OnPlayerMoved;
        InputEvent.OnPlayerJump -= OnPlayerJumped;
        InputEvent.OnPlayerSprint -= OnPlayerSprinted;
    }
}