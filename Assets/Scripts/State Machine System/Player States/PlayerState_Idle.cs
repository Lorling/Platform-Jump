using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Idle", menuName ="Data/StateMachine/PlayerState/Idle")]
public class PlayerState_Idle : PlayerState
{
    [Header("减速度")]
    [SerializeField] float deceleration = 5f;
    [Header("减速时要不要切换到站立动画")]
    [SerializeField] bool switchAnimationEnter = true;
    [Header("土狼时间")]
    [SerializeField] float coyoteTime = 0.1f;

    bool isSwitchAnimation;
    private float leavePlatformTime;

    public override void Enter()
    {
        isSwitchAnimation = false;
        if (switchAnimationEnter || currentSpeed == 0)
        {
            base.Enter();
            isSwitchAnimation = true;
        }

        currentSpeed = player.moveSpeed;

        leavePlatformTime = 0;

        player.dashCount = 1;
    }

    public override void Update()
    {
        if (player.Victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Vectory));
        }

        if (input.JumpInputBuffer || input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (input.Dash && player.canDash)
        {
            if (input.UpInputBuffer)
            {
                stateMachine.SwitchState(typeof(PlayerState_UpDash));
                return;
            }
            stateMachine.SwitchState(typeof (PlayerState_Dash));
        }

        if (!switchAnimationEnter && !isSwitchAnimation && currentSpeed == 0)
        {
            base.Enter();
            isSwitchAnimation = true;
        }

        if (!player.IsGround)
        {
            if (leavePlatformTime == 0) leavePlatformTime = Time.time;
            if (Time.time - leavePlatformTime > coyoteTime || input.Move)
            {
                stateMachine.SwitchState(typeof(PlayerState_Fall));
            }
            return;
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        player.SetVelocityX(currentSpeed * player.transform.localScale.x); 
    }
}
