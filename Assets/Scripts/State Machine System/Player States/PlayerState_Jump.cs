using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Jump", menuName = "Data/StateMachine/PlayerState/Jump")]
public class PlayerState_Jump : PlayerState
{
    [SerializeField] float jumpSpeed = 7f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 20f;
    [SerializeField] float minimumJumpTime = 0.1f;

    bool IsPressJump;

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(jumpSpeed);
        currentSpeed = player.moveSpeed;

        IsPressJump = true;
    }

    public override void Update()
    {
        if(input.StopJump) IsPressJump = false;
        if ((!IsPressJump && StateDuration >= minimumJumpTime) || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        if(input.Move) currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.fixedDeltaTime);
        player.Move(player.IsWall ? 0 : currentSpeed);
    }
}
