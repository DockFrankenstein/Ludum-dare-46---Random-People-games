using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Note the sound Manager MUST BE IN THE SCENE,
//for you to be able to call these commands
[SerializeField]
public class SoundManager : MonoBehaviour
{
    
    public static AudioSource audioSrc;
    public static AudioClip windSound;


    private void Start()
    {
        //Initialize the audioSource
        audioSrc = GetComponent<AudioSource>();

        //Find the sounds and store them in a variable to be used later on
        windSound = Resources.Load<AudioClip>("Wind");
    }

    //Set the volume to what the user wishes
    //This can be used in the volume section
    //and it takes in a value from 0 to 100

    public static void setVolume(int volume)
    {
        //Set the volume
        audioSrc.volume = volume / 100;
    }

    //Enter the sound you wish to play
    //ex :
    //deathSound = Resources.load<AudioClip> ("death");
    //PlaySound(deathSound);
    //NOTE: The sound must be stored in the Resources folder

    public static void PlaySound(AudioClip audioClip)
    {
        audioSrc.PlayOneShot(audioClip);
    }

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
