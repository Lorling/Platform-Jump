using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Fall", menuName = "Data/StateMachine/PlayerState/Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
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

        if (input.Jump && jumpCount == 1)
        {
            jumpCount--;
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }
    }

    public override void PhysicUpdate()
    {
        if (input.Move) currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.fixedDeltaTime);
        player.Move(player.IsWall ? 0 : currentSpeed);

        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
    }
}
