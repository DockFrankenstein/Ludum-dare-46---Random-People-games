using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class LevelManager : MonoBehaviour
{
    static int currentScene;
    public static LevelManager current;
    public Image fadePanel;
    public bool fading = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        current = this;       
        if (current == null)
        {
            DontDestroyOnLoad(gameObject);
            current = this;
        }
        else
        { Destroy(gameObject); }
    }

    public void LoadNextLevel()
    {
        if(!fading)
            StartCoroutine(LoadScene(++currentScene));
    }

    public void LoadSpecificLevel(int sceneIndex)
    {
        currentScene = sceneIndex;
        StartCoroutine(LoadScene(sceneIndex));
    }


    IEnumerator LoadScene(int sceneIndex)
    {
        fading = true;
        for(float t = 0; t <= 2; t+=0.1f)
        {
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t / 2);
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene(sceneIndex);
        for (float t = 2; t >= 0; t -= 0.1f)
        {
            Debug.Log("showing");
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, t / 2);
            yield return new WaitForSeconds(0.1f);
        }
        fading = false;
    }
}