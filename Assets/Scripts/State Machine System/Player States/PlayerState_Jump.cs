using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Jump", menuName = "Data/StateMachine/PlayerState/Jump")]
public class PlayerState_Jump : PlayerState
{
    [Header("ˮƽ�����ٶ�")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float deceleration = 20f;
    [Header("��С��Ծʱ��")]
    [SerializeField] float minimumJumpTime = 0.1f;
    [Header("����Ч��")]
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] ParticleSystem doubleJumpVFX;
    [Header("�ٶ�˥������")]
    [SerializeField] AnimationCurve speedCurve;

    bool IsPressJump;

    public override void Enter()
    {
        base.Enter();

        input.JumpInputBuffer = false;

        //��ֹ�ж��ٶ�С����ֱ���л�������״̬
        player.SetVelocityY(8f);

        currentSpeed = player.moveSpeed;

        IsPressJump = true;

        if(player.jumpCount == 1) Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
        else Instantiate(doubleJumpVFX, player.transform.position, Quaternion.identity);
    }

    public override void Update()
    {
        if(input.StopJump) IsPressJump = false;
        if ((!IsPressJump && StateDuration >= minimumJumpTime) || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }

        if(input.Jump && StateDuration < minimumJumpTime)
        {
            input.SetJumpInputBuffer();
        }
    }

    public override void PhysicUpdate()
    {
        if(input.Move) currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.fixedDeltaTime);
        player.Move(player.IsWall ? 0 : currentSpeed);

        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
    }
}
