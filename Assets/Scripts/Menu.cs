using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Options;

    public void Start()
    {
        Options.active = false;
    }

    public void mStart()
    {
        SceneManager.LoadScene("Level1 - 1d");
    }

    public void mLevel1()
    {
        SceneManager.LoadScene("Level1 - 1d");
    }

    public void mLevel2()
    {
        SceneManager.LoadScene("Level2 - new direction");
    }

    public void mOptions()
    {
        Options.active = true;
    }

    public void mCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void mExit()
    {
        // placeholder text i don't know how to quit out of the game in c# xd
    }

    public void oEnglish()
    {
        // placeholder text, replace when languages become an option
    }
}
