using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(currentSceneIndex >= SceneManager.sceneCount) 
        {
            //��ǰ�Ѿ������һ������
            SceneManager.LoadScene(currentSceneIndex);
            return;
        }

        SceneManager.LoadScene(currentSceneIndex);
    }

    public static void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
