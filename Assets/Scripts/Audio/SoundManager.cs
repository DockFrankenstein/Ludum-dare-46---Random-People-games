using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SoundManager : MonoBehaviour
{
    
    public static AudioSource audioSrc;

    //Adjust the volume from inspector 
    //if you wish to do so

    [Range(0, 100)]
    public int volume = 100;


    private void Start()
    {
        //Initialize the audioSource
        audioSrc = GetComponent<AudioSource>();
        //Set the start volume to the volume assigned in the inspector
        audioSrc.volume = volume / 100;
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
}
