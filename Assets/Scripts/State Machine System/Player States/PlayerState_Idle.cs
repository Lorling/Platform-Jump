using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Idle", menuName ="Data/StateMachine/PlayerState/Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 5f;
    [SerializeField] bool switchAnimationEnter = true;
    bool isSwitchAnimation;

    public override void Enter()
    {
        isSwitchAnimation = false;
        if (switchAnimationEnter || currentSpeed == 0)
        {
            base.Enter();
            isSwitchAnimation = true;
        }

        currentSpeed = player.moveSpeed;
    }

    public override void Update()
    {
        if(input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if(!switchAnimationEnter && !isSwitchAnimation && currentSpeed == 0)
        {
            base.Enter();
            isSwitchAnimation = true;
        }
    }

    public override void PhysicUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        player.SetVelocityX(currentSpeed * player.transform.localScale.x); 
    }
}
