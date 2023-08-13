using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Run", menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceration = 5f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.moveSpeed;
    }

    public override void Update()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceration * Time.fixedDeltaTime);

        player.Move(currentSpeed * input.AxesX);
    }
}
