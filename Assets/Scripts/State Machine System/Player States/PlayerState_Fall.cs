using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Fall", menuName = "Data/StateMachine/PlayerState/Fall")]
public class PlayerState_Fall : PlayerState
{
    [Header("速度曲线")]
    [SerializeField] AnimationCurve speedCurve;
    [Header("水平方向速度")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 15f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.moveSpeed;
    }

    public override void Update()
    {
        if (player.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.JumpInputBuffer || input.Jump)
        {
            if(player.jumpCount > 0)
            {
                stateMachine.SwitchState(typeof(PlayerState_Jump));
            }
            else
            {
                input.SetJumpInputBuffer();
            }
        }
    }

    public override void PhysicUpdate()
    {
        if (input.Move) currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.fixedDeltaTime);
        player.Move(currentSpeed);

        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
    }
}
