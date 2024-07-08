using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController _player;
    protected Animator _animator;

    public PlayerState(PlayerController player, Animator animator)
    {
        _player = player;
        _animator = animator;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
public class StandingState : PlayerState
{
    public StandingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _animator.SetBool("isWalking", false);
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isJumping",false);
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
    }
}
public class WalkingState : PlayerState
{
    public  WalkingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        if (!_player.IsGrounded()) return;
        _player.Move(_player.walkSpeed);
        _animator.SetBool("isWalking", true);
    }

    public override void UpdateState()
    {
        _player.Move(_player.walkSpeed);
    }

    public override void ExitState()
    {
        _animator.SetBool("isWalking", false);
    }
}

public class RunningState : PlayerState
{
    public RunningState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        if (!_player.IsGrounded()) return;
        _player.Move(_player.sprintSpeed);
        _animator.SetBool("isRunning", true);
    }

    public override void UpdateState()
    {
        _player.Move(_player.sprintSpeed);
    }

    public override void ExitState()
    {
        _animator.SetBool("isRunning", false);
    }
}

public class JumpingState : PlayerState
{
    public JumpingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _animator.SetBool("isJumping",true);
        Debug.LogWarning($"{_animator.GetBool("isJumping")}");
        _player.Jump();
    }

    public override void UpdateState()
    {
        if (_player.IsGrounded()) return;
        _animator.SetBool("isJumping",true);
    }

    public override void ExitState()
    {
        _animator.SetBool("isJumping",false);
    }
}

public class AttackingState : PlayerState
{
    public AttackingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _animator.SetBool("isAttacking", true);
    }

    public override void UpdateState()
    {
        _animator.SetBool("isAttacking", true);
    }

    public override void ExitState()
    {
        _animator.SetBool("isAttacking",false);
    }
}

