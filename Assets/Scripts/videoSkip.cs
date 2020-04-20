using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videoSkip : MonoBehaviour
{
    public string sceneToLoad = "";
    public float videoLenght;

    private void Awake()
    {
        StartCoroutine(waitForVideo());
    }

    private IEnumerator waitForVideo()
    {
        yield return new WaitForSeconds(videoLenght + 0.5f);
        LoadScene();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
