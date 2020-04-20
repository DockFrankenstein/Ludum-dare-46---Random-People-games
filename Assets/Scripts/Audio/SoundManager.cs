using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class SoundManager : MonoBehaviour
{
    public static SoundManager current;
    public static AudioSource audioSource;
    public AudioClip windSound;


    [Range(0, 1)]
    float volume = 1;
    
    public enum Sound
    {
        Wind = 0,
        Puzzle,
        Theme
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        current = this;
    }


    /// <param name="volume">volume level in range from 0 to 100</param>
    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public static void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
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

        for (float t = 0; t <= 2; t += 0.1f)
        {
            SetVolume(curve.Evaluate(t));
            yield return new WaitForSeconds(0.1f);
        }

        curve = AnimationCurve.Linear(0, 0, 2, 1);
        audioSource.clip = clip;


        for (float t = 0; t <= 2; t += 0.1f)
        {
            SetVolume(curve.Evaluate(t));
            yield return new WaitForSeconds(0.1f);
        }

    }

}
