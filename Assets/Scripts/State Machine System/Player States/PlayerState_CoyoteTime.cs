using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_CoyoteTime", menuName = "Data/StateMachine/PlayerState/CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 15f;
    [Header("ÍÁÀÇÊ±¼ä")]
    [SerializeField] float coyoteTime = 0.1f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.moveSpeed;
    }

    public override void Update()
    {
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (input.Dash && player.canDash)
        {
            if (input.UpInputBuffer) stateMachine.SwitchState(typeof(PlayerState_UpDash));
            stateMachine.SwitchState(typeof(PlayerState_Dash));
        }

        if (!input.Move || StateDuration > coyoteTime)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.fixedDeltaTime);

        player.Move(currentSpeed);
    }
}
