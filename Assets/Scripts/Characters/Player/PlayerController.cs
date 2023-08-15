using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerGroundDetector groundDetector;
    PlayerWallDetector wallDetector;
    PlayerInput input;
    Rigidbody rigidbody;

    // 二段跳
    [Header("默认二段跳次数，除了这个参数，其他的不要碰")]
    public int JumpCount = 0;
    public int jumpCount;

    public bool IsGround => groundDetector.IsGround;
    public bool IsFalling => rigidbody.velocity.y < 0 && !IsGround;
    public float moveSpeed => Mathf.Abs(rigidbody.velocity.x);

    public bool IsWall => wallDetector.IsWall;

    public List<StarGem> starGems = new List<StarGem>();

    void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        wallDetector = GetComponentInChildren<PlayerWallDetector>();
        input = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
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
}
