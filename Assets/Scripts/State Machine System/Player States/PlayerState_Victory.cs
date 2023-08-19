using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Vectory", menuName = "Data/StateMachine/PlayerState/Vectory")]
public class PlayerState_Vectory : PlayerState
{
    [SerializeField] AudioClip[] vectoryAudio;

    public override void Enter()
    {
        base.Enter();

        player.Victory = false;

        player.SetVelocity(new Vector3 (0, 0, 0));

        SoundEffectsPlayer.audioSource.PlayOneShot(vectoryAudio[Random.Range(0, vectoryAudio.Length)]);
    }
}
