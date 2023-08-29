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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex + 1 >= SceneManager.sceneCount) 
        {
            //当前已经是最后一个场景
            SceneManager.LoadScene(currentSceneIndex);
            return;
        }

        SceneManager.LoadScene(currentSceneIndex + 1);
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
