using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelDefeated;
    [SerializeField] AudioClip[] defeatedAudio;
    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;

    void OnEnable()
    {
        levelDefeated.AddListener(ShowDefeatedUI);

        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }

    void OnDisable()
    {
        levelDefeated.RemoveListener(ShowDefeatedUI);

        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    void ShowDefeatedUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        SoundEffectsPlayer.audioSource.PlayOneShot(defeatedAudio[Random.Range(0, defeatedAudio.Length)]);
        // �����Ϸ��ʼʱ������꣬������Ҫ����
        //Cursor.lockState = CursorLockMode.None;
    }
}
