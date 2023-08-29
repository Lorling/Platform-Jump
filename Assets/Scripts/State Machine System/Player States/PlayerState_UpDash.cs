using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_UpDash", menuName = "Data/StateMachine/PlayerState/UpDash")]
public class PlayerState_UpDash : PlayerState
{
    [SerializeField] float dashSpeed = 15f;
    [SerializeField] float dashTime = 0.15f;

    public override void Enter()
    {
        base.Enter();
        player.dashCount--;
        player.dashStartTime = Time.time;
    }

    public override void Exit()
    {
        player.SetVelocity(new Vector3(0, 0, 0));
    }

    public override void Update()
    {
        ObjectPool.Instance.Get();
        if (input.JumpInputBuffer || input.Jump)
        {
            if (StateDuration > dashTime)
            {
                if (player.IsGround || player.jumpCount > 0)
                {
                    stateMachine.SwitchState(typeof(PlayerState_Jump));
                    return;
                }
            }
            else
                input.SetJumpInputBuffer();
        }

        if (StateDuration > dashTime)
        {
            if (player.IsGround) stateMachine.SwitchState(typeof(PlayerState_Idle));
            else stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.SetVelocity(new Vector3(0, dashSpeed, 0));
    }
}
