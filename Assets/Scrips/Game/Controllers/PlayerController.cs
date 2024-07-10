using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private CharacterController _character;
    private float _sprintSpeed = 2f;
    private float _walkSpeed = 1f;
    private float _jumpHeight = 1f;
    private float _verticalVelocity;
    private float _groundedTimer;
    private float _gravityValue = 9.81f;
    private StateMachine _stateMachine;
    public float sprintSpeed => _sprintSpeed;
    public float walkSpeed => _walkSpeed;


    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new StandingState(this, _animator));
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
        if (!CanChangeState()) return;
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
        if (IsGrounded())
        {
            if (_groundedTimer > 0)
            {
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(_jumpHeight * 2 * _gravityValue);
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, .1f);
    }


    public void Move(float speed)
    {
        bool groundedPlayer = _character.isGrounded;
        if (groundedPlayer) _groundedTimer = 0.2f;
        if (_groundedTimer > 0) _groundedTimer -= Time.deltaTime;
        if (groundedPlayer && _verticalVelocity < 0) _verticalVelocity = 0f;
        _verticalVelocity -= _gravityValue * Time.deltaTime;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        move *= speed;
        
        if (move.magnitude > 0.05f) gameObject.transform.forward = move;
        
        move.y = _verticalVelocity;
        _character.Move(move * Time.deltaTime);
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