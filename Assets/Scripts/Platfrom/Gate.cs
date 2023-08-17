using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTrigger;

    void OnEnable()
    {
        gateTrigger.AddListener(Open);
    }

    void OnDisable()
    {
        gateTrigger.RemoveListener(Open);
    }

    void Open()
    {
        Destroy(gameObject);
    }
}
