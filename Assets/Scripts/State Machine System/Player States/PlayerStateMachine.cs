using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        //对玩家的状态进行初始化
    }
}
