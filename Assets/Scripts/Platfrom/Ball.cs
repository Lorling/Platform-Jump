using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //�����봥�������ǲ������
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) > 1.0f && other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDefeated();
        }
    }
}
