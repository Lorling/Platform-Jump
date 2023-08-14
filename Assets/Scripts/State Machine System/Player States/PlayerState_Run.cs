using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Run", menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.moveSpeed;
    }

    public override void Update()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof (PlayerState_Idle));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof (PlayerState_Jump));
        }

        if (!player.IsGround)
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
