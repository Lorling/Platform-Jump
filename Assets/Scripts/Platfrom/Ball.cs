using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //检测进入触发器的是不是玩家
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > 1.0f && other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDefeated();
        }
    }
}
