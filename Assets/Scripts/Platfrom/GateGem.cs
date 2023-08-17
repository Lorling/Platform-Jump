using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGem : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField] VoidEventChannel gateTrigger;
    
    void OnTriggerEnter(Collider other)
    {
        //�����봥�������ǲ������
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            gateTrigger.BroadCast();

            //����ĵȼ������
            /*if(Delegate != null)
            {
                Delegate.Invoke();
            }*/

            SoundEffectsPlayer.audioSource.PlayOneShot(pickupSFX);
            Instantiate(pickupVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
