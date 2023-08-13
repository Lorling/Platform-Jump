using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody rigidbody;

    public float moveSpeed => Mathf.Abs(rigidbody.velocity.x);

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        input.EnableGameplay();
    }

    public void Move(float speed)
    {
        if(input.Move)
            transform.localScale = new Vector3(input.AxesX, transform.localScale.y, transform.localScale.z);
        SetVelocityX(speed);
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
}
