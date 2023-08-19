using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Defeated", menuName = "Data/StateMachine/PlayerState/Defeated")]
public class PlayerState_Defeated : PlayerState
{
    [Header("À¿Õˆ“Ù–ß")]
    [SerializeField] AudioClip[] deathSFX;
    [Header("À¿ÕˆÃÿ–ß")]
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] VoidEventChannel PlayerDefeated;

    public override void Enter()
    {
        base.Enter();

        Instantiate(deathVFX, player.transform.position, Quaternion.identity);
        SoundEffectsPlayer.audioSource.PlayOneShot(deathSFX[Random.Range(0, deathSFX.Length)]);

        PlayerDefeated.BroadCast();
    }

    public override void Update()
    {
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }
}
