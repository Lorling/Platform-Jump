using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;

    [Header("跳跃预输入保留时间")]
    [SerializeField] float jumpInputBufferTime = 0.2f;
    WaitForSeconds waitJumpInputBufferTime;
    public bool JumpInputBuffer { get; set; }

    [Header("向上冲刺时上键预输入保留时间")]
    [SerializeField] float upInputBufferTime = 0.1f;
    WaitForSeconds waitUpInputBufferTime;
    public bool Up => inputActions.Gameplay.Up.IsPressed();
    public bool UpInputBuffer { get; private set; }

    public bool Dash => inputActions.Gameplay.Dash.WasPressedThisFrame();
    public bool Jump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool Move => AxesX != 0;

    public float AxesX;

    float LeftTime;
    float RightTime;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
        waitUpInputBufferTime = new WaitForSeconds(upInputBufferTime);
    }

    void Update()
    {
        CheckMoveDirection();
        if(Up) SetUPInputBuffer();
    }

    void OnEnable()
    {
        inputActions.Gameplay.Jump.canceled += delegate
        {
            JumpInputBuffer = false;
        };
    }

    void CheckMoveDirection()
    {
        if (inputActions.Gameplay.LeftMove.WasPressedThisFrame())
        {
            LeftTime = Time.time;
        }
        if (inputActions.Gameplay.RightMove.WasPressedThisFrame())
        {
            RightTime = Time.time;
        }
        if (inputActions.Gameplay.LeftMove.IsPressed() && inputActions.Gameplay.RightMove.IsPressed())
        {
            AxesX = (LeftTime > RightTime) ? -1 : 1;
        }
        else if (inputActions.Gameplay.LeftMove.IsPressed())
        {
            AxesX = -1;
        }
        else if (inputActions.Gameplay.RightMove.IsPressed())
        {
            AxesX = 1;
        }
        else AxesX = 0;
    }

    public void EnableGameplay()
    {
        inputActions.Gameplay.Enable();
        //锁定鼠标
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetJumpInputBuffer()
    {
        //防止同一个协程重复开启
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        JumpInputBuffer = true;

        yield return waitJumpInputBufferTime;

        JumpInputBuffer = false;
    }

    public void SetUPInputBuffer()
    {
        //防止同一个协程重复开启
        StopCoroutine(nameof(UpInputBufferCoroutine));
        StartCoroutine(nameof(UpInputBufferCoroutine));
    }

    IEnumerator UpInputBufferCoroutine()
    {
        UpInputBuffer = true;

        yield return waitUpInputBufferTime;

        UpInputBuffer = false;
    }

    public void DisableGameplayInputs()
    {
        inputActions.Disable();
    }
}
