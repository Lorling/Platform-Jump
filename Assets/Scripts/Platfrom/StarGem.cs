using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;

    Collider collider;
    MeshRenderer renderer;

    void Awake()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponentInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //检测进入触发器的是不是玩家
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.jumpCount = player.JumpCount + 1;
            player.starGems.Add(this);

            SoundEffectsPlayer.audioSource.PlayOneShot(pickupSFX);
            Instantiate(pickupVFX, transform.position, Quaternion.identity);

            collider.enabled = false;
            renderer.enabled = false;

            //定时恢复
            //Invoke(nameof(Reset), 3f);
        }
    }

    public void Reset()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }
}
