using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[SerializeField]
public class SoundManager : MonoBehaviour
{
    public static SoundManager current;
    public static AudioSource audioSource;
    public AudioSource windAudioSource;
    public AudioClip windSound;
    public AudioClip currentAudioClip;
    public AudioMixer master;

    [Range(0, 1)]
    float volume = 1;
    
    public enum Sound
    {
        Wind = 0,
        Puzzle,
        Theme
    }

    private void Awake()
    {
        print(current != this);
        if (current == null)
        {
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            current = this;
        }
        else if (current != this)
        {
            Debug.Log("passing onto current");
            current.FadeInAudio();
            current.PlaySound(this.currentAudioClip);
            Destroy(gameObject);
        }
    }

    public static void DisableMusic()
    {
        if (current != null)
        {
            current.currentAudioClip = null;
            current.windAudioSource.Stop();
            audioSource.Stop();
        }
    }


    /// <param name="volume">volume level in range from 0 to 100</param>
    public void SetVolume(float volume)
    {
        master.SetFloat("MainVolume", volume * 100 - 100);
    }

    public void PlaySound(AudioClip clip)
    {
        print(audioSource == current.GetComponent<AudioSource>());
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
        audioSource.Play();
        currentAudioClip = clip;
    } 
    
    public void FadeOutAudio()
    {
        StartCoroutine(FadeOut());
    }
    public void FadeInAudio()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        AnimationCurve curve = AnimationCurve.Linear(0, 1, 2, 0);

        for (float t = 0; t <= 2; t += 0.1f)
        {
            SetVolume(curve.Evaluate(t));
                
            yield return new WaitForSeconds(0.1f);
        }

    }
    IEnumerator FadeIn()
    {
        AnimationCurve curve = AnimationCurve.Linear(0, 0, 2, 1);
        
        for (float t = 0; t <= 2; t += 0.1f)
        {
            SetVolume(curve.Evaluate(t));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void CrossfadeCurrentClip(AudioClip clip)
    {
        StartCoroutine(Crossfade(clip));
    }

    IEnumerator Crossfade(AudioClip clip)
    {
        AnimationCurve curve = AnimationCurve.Linear(0, 1, 2, 0);

        for (float t = 0; t <= 2; t += 0.05f)
        {
            SetVolume(curve.Evaluate(t));
            yield return new WaitForSeconds(0.05f);
        }

        curve = AnimationCurve.Linear(0, 0, 2, 1);
        audioSource.clip = clip;
        audioSource.enabled = false;
        audioSource.enabled = true;


        for (float t = 0; t <= 2; t += 0.05f)
        {
            SetVolume(curve.Evaluate(t));
            yield return new WaitForSeconds(0.05f);
        }

    }
}
