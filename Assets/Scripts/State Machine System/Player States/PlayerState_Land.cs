using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Land", menuName = "Data/StateMachine/PlayerState/Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime = 0.2f;

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(0);
        jumpCount = JumpCount;
    }

    public override void Update()
    {
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (StateDuration < stiffTime) return;

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
