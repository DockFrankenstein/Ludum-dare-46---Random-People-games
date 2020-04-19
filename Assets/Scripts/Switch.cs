using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
//KubikZ: Refactorings, key handling, and little repairs
public class Switch : MonoBehaviour
{
    bool isOn;
    bool captureForUserSwitching = false;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    [Header("KeyBinds")]
    public KeyCode switchKeybind = KeyCode.Space;


    void Update()
    {
        if (captureForUserSwitching)
            if (Input.GetKeyDown(switchKeybind))
                SwitchSwitch();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            captureForUserSwitching = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            captureForUserSwitching = false;
    }

    void SwitchSwitch()
    {
        if (isOn)
            Deactivate();
        else
            Activate();
<<<<<<< HEAD
=======
        }
        else {
            // If you want something to happen when 
            //something else collides with the switch
            //then do it here
            collidedWithSwitch = false;
        }
>>>>>>> 67857d1c5b252985334becb8b155369d570c8ace
    }

    void Activate()
    {
        isOn = true;
        OnActivate.Invoke();
        //TO DO: Change sprite
    }
    void Deactivate()
    {
        isOn = false;
        OnDeactivate.Invoke();
        //TO DO: Change sprite
    }
<<<<<<< HEAD
=======
    //Returns true or false depending on if the player has collided with the script
    
>>>>>>> 67857d1c5b252985334becb8b155369d570c8ace

}
