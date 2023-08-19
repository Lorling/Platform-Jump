using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //�����봥�������ǲ������
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDefeated();
        }
    }
}
