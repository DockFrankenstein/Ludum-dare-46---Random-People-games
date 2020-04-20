using UnityEngine;
using UnityEngine.SceneManagement;

class LevelManager : MonoBehaviour
{
    static int currentScene;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(++currentScene);
    }

    public static void LoadSpecificLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        currentScene = sceneIndex;
    }


}