using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearance;

    void OnEnable()
    {
        levelClearance.AddListener(ShowUI);
    }

    void OnDisable()
    {
        levelClearance.RemoveListener(ShowUI);
    }

    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
}
