using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeperateLevelLoader : MonoBehaviour
{
    public bool LoadOnTrigger = false;
    public string sceneOnTriggerName;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LoadOnTrigger && collision.tag == "Player")
        {
            LoadScene(sceneOnTriggerName);
        }
    }
}
