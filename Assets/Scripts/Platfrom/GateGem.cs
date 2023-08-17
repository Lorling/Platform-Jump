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
        //检测进入触发器的是不是玩家
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            gateTrigger.BroadCast();

            //上面的等价与这个
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
