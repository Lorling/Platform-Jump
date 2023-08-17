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
        //�����봥�������ǲ������
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.jumpCount = player.JumpCount + 1;
            player.starGems.Add(this);

            SoundEffectsPlayer.audioSource.PlayOneShot(pickupSFX);
            Instantiate(pickupVFX, transform.position, Quaternion.identity);

            collider.enabled = false;
            renderer.enabled = false;

            //��ʱ�ָ�
            //Invoke(nameof(Reset), 3f);
        }
    }

    public void Reset()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }
}
