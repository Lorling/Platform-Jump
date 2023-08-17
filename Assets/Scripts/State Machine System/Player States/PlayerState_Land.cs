using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Land", menuName = "Data/StateMachine/PlayerState/Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    [Header("硬直时间")]
    [SerializeField] float stiffTime = 0.2f;
    [Header("减速度")]
    [SerializeField] float deceleration = 20f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.moveSpeed;

        player.SetVelocityY(0);
        player.jumpCount = player.JumpCount;

        //重新生成道具
        if(player.starGems.Count > 0)
        {
            player.ReSetStarGem();
        }
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

    public override void PhysicUpdate()
    {
        if(input.Move) currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.fixedDeltaTime);
        else currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
