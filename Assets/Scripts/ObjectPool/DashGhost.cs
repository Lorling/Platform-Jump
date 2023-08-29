using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashGhost : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float activeTime = 0.1f;
    private float startTime;
    [SerializeField] AnimationCurve curve;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
        startTime = Time.time;
    }

    private void Update()
    {
        if(Time.time > (startTime + activeTime)) {
            ObjectPool.Instance.Push(gameObject);
        }
    }
}
