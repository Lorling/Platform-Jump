using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelDefeated;

    void OnEnable()
    {
        levelDefeated.AddListener(ShowDefeatedUI);
    }

    void OnDisable()
    {
        levelDefeated.RemoveListener(ShowDefeatedUI);
    }

    void ShowDefeatedUI()
    {
        Debug.Log(1);
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
}
