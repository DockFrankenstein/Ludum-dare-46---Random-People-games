using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class SoundManager : MonoBehaviour
{

    public static AudioSource audioSource;
    public static AudioClip windSound;
    
    
    [Range(0, 100)]
    public int volume = 100;
    
    public enum Sound
    {
        Wind = 0,

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        windSound = Resources.Load<AudioClip>("Wind");
        audioSource.volume = volume / 100;
    }


    /// <param name="volume">volume level in range from 0 to 100</param>
    public static void SetVolume(int volume)
    {
        audioSource.volume = volume / 100;
    }

    public static void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public static void Play(Sound sound)
    {
        switch (sound)
        {
            case Sound.Wind:
                audioSource.PlayOneShot(windSound);
                break;
        }
    }
}
