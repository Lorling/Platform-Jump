using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelStart;
    [SerializeField] AudioClip startVoice;

    void LevelStart()
    {
        levelStart.BroadCast();

        GetComponent<Animator>().enabled = false;
        GetComponent<Canvas>().enabled = false;
    }

    void PlayerStartVoice()
    {
        SoundEffectsPlayer.audioSource.PlayOneShot(startVoice);
    }
}
