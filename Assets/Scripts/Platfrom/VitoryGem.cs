using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField] VoidEventChannel levelClearance;

    void OnTriggerEnter(Collider other)
    {
        //�����봥�������ǲ������
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            levelClearance.BroadCast();

            SoundEffectsPlayer.audioSource.PlayOneShot(pickupSFX);
            Instantiate(pickupVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
