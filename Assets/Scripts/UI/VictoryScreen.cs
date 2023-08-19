using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearance;
    [SerializeField] StringEventChannel ClearTime;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Text clearTime;

    void OnEnable()
    {
        levelClearance.AddListener(ShowUI);
        ClearTime.AddListener(SetClearTime);

        nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
    }

    void OnDisable()
    {
        levelClearance.RemoveListener(ShowUI);
        ClearTime.RemoveListener(SetClearTime);

        nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
    }

    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        // �����Ϸ��ʼʱ������꣬������Ҫ����
        //Cursor.lockState = CursorLockMode.None;
    }

    void SetClearTime(string clearTime)
    {
        this.clearTime.text = clearTime;
    }
}
