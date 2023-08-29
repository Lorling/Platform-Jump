using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerGroundDetector groundDetector;
    PlayerInput input;
    Rigidbody rigidbody;
    public AudioSource audioSource;

    // 二段跳
    [Header("默认二段跳次数，除了这个参数，其他的不要碰")]
    public int JumpCount = 0;
    public int jumpCount;

    // 冲刺
    public int dashCount = 1;
    public bool canDash => Time.time - dashStartTime > dashCD;
    public float dashStartTime = -100.0f;
    public float dashCD = 0.5f;

    public bool IsGround => groundDetector.IsGround;
    public bool IsFalling => rigidbody.velocity.y < 0 && !IsGround;
    public float moveSpeed => Mathf.Abs(rigidbody.velocity.x);

    public bool Victory { get; set; }

    public List<StarGem> starGems = new List<StarGem>();

    [SerializeField] VoidEventChannel levelClearance;

    void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnEnable()
    {
        levelClearance.AddListener(OnLevelClearance);
    }

    void OnDisable()
    {
        levelClearance.RemoveListener(OnLevelClearance);
    }

    void OnLevelClearance()
    {
        Victory = true;

        input.DisableGameplayInputs();
    }

    void Start()
    {
        input.EnableGameplay();

        rigidbody.useGravity = false;
    }

    public void Move(float speed)
    {
        if(input.Move)
            transform.localScale = new Vector3(input.AxesX, transform.localScale.y, transform.localScale.z);
        SetVelocityX(speed * input.AxesX);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3 (velocityX, rigidbody.velocity.y, rigidbody.velocity.z);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3 (rigidbody.velocity.x, velocityY, rigidbody.velocity.z);
    }

    public void ReSetStarGem()
    {
        foreach(var gem in starGems)
        {
            gem.Reset();
        }
        starGems.Clear();
    }

    public void OnDefeated()
    {
        input.DisableGameplayInputs();

        rigidbody.velocity = new Vector3(0, 0, 0);
        GetComponent<Collider>().enabled = false;

        GetComponent<PlayerStateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }
}
