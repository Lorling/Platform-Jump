using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;

    Vector2 axes => inputActions.Gameplay.Move.ReadValue<Vector2>();

    [Header("��ԾԤ���뱣��ʱ��")]
    [SerializeField] float jumpInputBufferTime = 0.2f;
    WaitForSeconds waitJumpInputBufferTime;
    public bool JumpInputBuffer { get; set; }

    public bool Jump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool Move => AxesX != 0;

    public float AxesX => axes.x;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }

    void OnEnable()
    {
        inputActions.Gameplay.Jump.canceled += delegate
        {
            JumpInputBuffer = false;
        };
    }

    public void EnableGameplay()
    {
        inputActions.Gameplay.Enable();
        //�������
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetJumpInputBuffer()
    {
        //��ֹͬһ��Э���ظ�����
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        JumpInputBuffer = true;

        yield return waitJumpInputBufferTime;

        JumpInputBuffer = false;
    }

    public void DisableGameplayInputs()
    {
        inputActions.Disable();
    }
}
