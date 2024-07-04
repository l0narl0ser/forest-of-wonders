public class StateMachine
{
    private PlayerState _currentState;

    public PlayerState currentState => _currentState;

    public void Initialize(PlayerState startingState)
    {
        _currentState = startingState;
        startingState.EnterState();
    }

    public void ChangeState(PlayerState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void Update()
    {
        _currentState?.UpdateState();
    }
}