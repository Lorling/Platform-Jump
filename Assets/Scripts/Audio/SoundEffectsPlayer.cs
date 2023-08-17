using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public static AudioSource audioSource { get; private set; }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
}
