using UnityEngine;
using UnityEngine.UI;

public class ClearTimer : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] VoidEventChannel VoidLevelStart;
    [SerializeField] VoidEventChannel VoidLevelClearance;
    [SerializeField] VoidEventChannel VoidPlayerDefeated;
    [SerializeField] StringEventChannel StringClearTime;

    bool stop = true;

    float clearTime;

    void FixedUpdate()
    {
        if(!stop) clearTime += Time.fixedDeltaTime;

        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    void OnEnable()
    {
        VoidLevelStart.AddListener(StartTiming);
        VoidLevelClearance.AddListener(EndTiming);
        VoidPlayerDefeated.AddListener(OnlyEndTiming);
    }

    void OnDisable()
    {
        VoidLevelStart.RemoveListener(StartTiming);
        VoidLevelClearance.RemoveListener(EndTiming);
        VoidPlayerDefeated.RemoveListener(OnlyEndTiming);
    }

    void StartTiming()
    {
        stop = false;
    }

    void EndTiming()
    {
        stop = true;
        StringClearTime.BroadCast(System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff"));
        GetComponent<Canvas>().enabled = false;
    }

    void OnlyEndTiming()
    {
        stop = true;
    }
}
