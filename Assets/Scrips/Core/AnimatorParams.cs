using UnityEngine;

public static class AnimatorParams
{
    public static readonly int isWalking = Animator.StringToHash("isWalking");
    public static readonly int isRunning = Animator.StringToHash("isRunning");
    public static readonly int isJumping = Animator.StringToHash("isJumping");
    public static readonly int isAttacking = Animator.StringToHash("isAttacking");
}
