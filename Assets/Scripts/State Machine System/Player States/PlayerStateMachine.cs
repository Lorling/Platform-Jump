using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        //����ҵ�״̬���г�ʼ��
    }
}
