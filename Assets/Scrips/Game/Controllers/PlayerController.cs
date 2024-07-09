using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    public Rigidbody rigidBody => _rigidBody;

    [SerializeField] private Animator _animator;
    [SerializeField] private Interactor _interactor;

    private float _direction = 0f;
    private float _sprintSpeed = 4f;
    private float _walkSpeed = 2f;
    private float _jumpHeight = 7f;
    private StateMachine _stateMachine;
    public float sprintSpeed => _sprintSpeed;
    public float walkSpeed => _walkSpeed;


    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new StandingState(this,_animator));
        InputEvent.OnPlayerAttack += OnPlayerAttacked;
        InputEvent.OnPlayerInteract += OnPlayerInteracted;
        InputEvent.OnPlayerMove += OnPlayerMoved;
        InputEvent.OnPlayerJump += OnPlayerJumped;
        InputEvent.OnPlayerSprint += OnPlayerSprinted;
        InputEvent.OnPlayerStop += OnPlayerStopped;
    }
    private void Update()
    {
        _stateMachine.Update();
    }
    private void OnPlayerStopped()
    {
        if (!CanChangeState())
        {
            return;
        }
        _stateMachine.ChangeState(new StandingState(this, _animator));
    }

    private bool CanChangeState()
    {
        var currentState = _stateMachine.currentState.GetType();
        return currentState != typeof(StandingState) && currentState != typeof(JumpingState);
    }
    public bool CanAttack()
    {
        var currentState = _stateMachine.currentState.GetType();
        return currentState == typeof(AttackingState);
    }
    private void OnPlayerMoved()
    {
        _stateMachine.ChangeState(new WalkingState(this, _animator));
    }
    private void OnPlayerSprinted()
    {
        _stateMachine.ChangeState(new RunningState(this, _animator));
    }

    private void OnPlayerJumped()
    {
        _stateMachine.ChangeState(new JumpingState(this, _animator));
    }

    private void OnPlayerInteracted()
    {
        _interactor.Interact();
    }

    private void OnPlayerAttacked()
    {
        _stateMachine.ChangeState(new AttackingState(this, _animator));
    }
    

    public void Jump()
    {
        if (IsGrounded()) _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _jumpHeight);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, .1f);
    }


    public void Move(float speed)
    {
        _direction = Input.GetAxisRaw("Horizontal");
        Turn(_direction);
        _rigidBody.velocity = new Vector3(_direction * speed, _rigidBody.velocity.y, 0);
    }

    private void Turn(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
    

    private void OnDestroy()
    {
        InputEvent.OnPlayerAttack -= OnPlayerAttacked;
        InputEvent.OnPlayerInteract -= OnPlayerInteracted;
        InputEvent.OnPlayerMove -= OnPlayerMoved;
        InputEvent.OnPlayerJump -= OnPlayerJumped;
        InputEvent.OnPlayerSprint -= OnPlayerSprinted;
        InputEvent.OnPlayerStop -= OnPlayerStopped;
    }
}