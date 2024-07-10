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
        _animator.SetBool(AnimatorParams.isWalking, false);
        _animator.SetBool(AnimatorParams.isRunning, false);
        _animator.SetBool(AnimatorParams.isJumping,false);
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
        _player.Move(_player.walkSpeed);
        _animator.SetBool(AnimatorParams.isWalking, true);
    }

    public override void UpdateState()
    {
        _player.Move(_player.walkSpeed);
    }

    public override void ExitState()
    {
        _animator.SetBool(AnimatorParams.isWalking, false);
    }
}

public class RunningState : PlayerState
{
    public RunningState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _player.Move(_player.sprintSpeed);
        _animator.SetBool(AnimatorParams.isRunning, true);
    }

    public override void UpdateState()
    {
        _player.Move(_player.sprintSpeed);
    }

    public override void ExitState()
    {
        _animator.SetBool(AnimatorParams.isRunning, false);
    }
}

public class JumpingState : PlayerState
{
    public JumpingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _animator.SetBool(AnimatorParams.isJumping,true);
        _player.Jump();
    }

    public override void UpdateState()
    {
        if (_player.IsGrounded()) return;
        _animator.SetBool(AnimatorParams.isJumping,true);
        _player.Jump();

    }

    public override void ExitState()
    {
       _animator.SetBool(AnimatorParams.isJumping,false);
    }
}

public class AttackingState : PlayerState
{
    
    public AttackingState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void EnterState()
    {
        _animator.SetBool(AnimatorParams.isAttacking, true);
    }

    public override void UpdateState()
    {
        _animator.SetBool(AnimatorParams.isAttacking, true);
    }

    public override void ExitState()
    {
        _animator.SetBool(AnimatorParams.isAttacking,false);
    }
}

