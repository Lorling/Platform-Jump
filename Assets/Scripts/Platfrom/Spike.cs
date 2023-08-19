using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //检测进入触发器的是不是玩家
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDefeated();
        }
    }
}
