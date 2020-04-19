using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
//KubikZ: I've changed a little, way, way too much comment in my opinion
//well, there's no need to explain everything to that point :)
//also replaced string with enumerator, so there's no need to remember those names
//and to handle default case
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
=======

//Note the sound Manager MUST BE IN THE SCENE,
//for you to be able to call these commands
[SerializeField]
public class SoundManager : MonoBehaviour
{
    
    public static AudioSource audioSrc;
    public static AudioClip windSound;
>>>>>>> 67857d1c5b252985334becb8b155369d570c8ace


    private void Start()
    {
<<<<<<< HEAD
        audioSource = GetComponent<AudioSource>();
        windSound = Resources.Load<AudioClip>("Wind");
        audioSource.volume = volume / 100;
=======
        //Initialize the audioSource
        audioSrc = GetComponent<AudioSource>();

        //Find the sounds and store them in a variable to be used later on
        windSound = Resources.Load<AudioClip>("Wind");
>>>>>>> 67857d1c5b252985334becb8b155369d570c8ace
    }


    /// <param name="volume">volume level in range from 0 to 100</param>
    public static void SetVolume(int volume)
    {
        audioSource.volume = volume / 100;
    }

    public static void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
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
<<<<<<< HEAD
}
=======

    // if you wish to use a function to play sounds
    //then define it here by adding a case
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "wind":
                audioSrc.PlayOneShot(windSound);
                break;
        }
    }

    //To use this function just do :
    //SoundManager.PlaySound("wind or any other case the function supports")
}
>>>>>>> 67857d1c5b252985334becb8b155369d570c8ace
