using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class LevelManager : MonoBehaviour
{
<<<<<<< HEAD
    static int currentScene;
    public static LevelManager current;
    public SpriteRenderer fadePanel;
=======
    static int currentScene = 0;
>>>>>>> 8c8d16cd254c0c76dfd0d62f3f1ff55149c0856c

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        current = this;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadScene(++currentScene));
    }

    public void LoadSpecificLevel(int sceneIndex)
    {
        currentScene = sceneIndex;
        StartCoroutine(LoadScene(sceneIndex));
    }


    IEnumerator LoadScene(int sceneIndex)
    {
        for(float t = 0; t <= 2; t+=0.1f)
        {
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t / 2);
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene(sceneIndex);


        for (float t = 2; t <= 0; t -= 0.1f)
        {
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t / 2);
            yield return new WaitForSeconds(0.1f);
        }

    }
}