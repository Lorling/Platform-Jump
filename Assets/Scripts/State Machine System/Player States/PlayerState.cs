using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;
    protected PlayerInput input;
    protected PlayerController player;
    protected PlayerStateMachine stateMachine;

    protected float currentSpeed;

    [SerializeField] string stateName;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f;

    int stateHash;

    // 判断动画是否播放结束
    protected float StateDuration => Time.time - StateStartTime;
    float StateStartTime;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    public void Initialize(Animator animator, PlayerController player, PlayerInput input, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.player = player;
        this.input = input;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        StateStartTime = Time.time;
    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicUpdate()
    {

    }

    public virtual void Update()
    {

    }

    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }
}
