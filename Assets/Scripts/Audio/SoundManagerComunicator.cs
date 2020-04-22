using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerComunicator : MonoBehaviour
{
    public void DisableMusic()
    {
        SoundManager.DisableMusic();
    }

    public void SetVolume(float volume)
    {
        SoundManager.current.SetVolume(volume);
    }

    public void PlaySound(AudioClip clip)
    {
        SoundManager.current.PlaySound(clip);
    }

    public void FadeInAudio()
    {
        SoundManager.current.FadeInAudio();
    }

    public void FadeOutAudio()
    {
        SoundManager.current.FadeOutAudio();
    }

    public void CrossfadeCurrentClip(AudioClip clip)
    {
        SoundManager.current.CrossfadeCurrentClip(clip);
    }

    public void LoadNextLevel()
    {
        LevelManager.current.LoadNextLevel();
    }

    public void LoadSpecificLevel(int sceneIndex)
    {
        LevelManager.current.LoadSpecificLevel(sceneIndex);
    }

    public void ReloadScene()
    {
        LevelManager.current.ReloadScene();
    }
}
