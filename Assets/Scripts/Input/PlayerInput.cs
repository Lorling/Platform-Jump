using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;

    Vector2 axes => inputActions.Gameplay.Move.ReadValue<Vector2>();

    public bool Jump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool StopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool Move => AxesX != 0;

    public float AxesX => axes.x;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    public void EnableGameplay()
    {
        inputActions.Gameplay.Enable();
        //Ëø¶¨Êó±ê
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
