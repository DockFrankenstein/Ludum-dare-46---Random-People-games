using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Switch : MonoBehaviour
{
    //Obtain the switch gameobject
    [SerializeField]
    public static bool collidedWithSwitch = false;

    [Header("Required stuff")]
    [SerializeField]    
    public GameObject player;

    //We will use this gameobject to obtain 
    //the players position,tag and a few
    //other things if neccesarry


    void Start()
    {
        //if you wish the script to automatically find the player
        //then unhash the line of code below
        //player = this.gameObject;//
    }

    void Update()
    {

    }

    //When an object collides with this game object
    void onTriggerEnter2D(Collider other)
    {

        if (other.gameObject.tag == player.tag)
        {
            Activate();
        }
        else {
            // If you want something to happen when 
            //something else collides with the switch
            //then do it here
            collidedWithSwitch = false;
        }
    }

    //What we do when the user
    //collides with the button
    void Activate()
    {
        Debug.Log("Player has collided with switch");
        collidedWithSwitch = true;
    }


    //This function below is a boolean function,
    //and you can call it in an if statement like so:
    //if (Switch.CollidedWithSwitch())
    //{
    //  Debug.log("You have collided with the switch!")
    //}


    public static bool CollidedWithSwitch() 
    { 
        if (collidedWithSwitch == true) return true; else return false; 
    }
    //Returns true or false depending on if the player has collided with the script
    

}
