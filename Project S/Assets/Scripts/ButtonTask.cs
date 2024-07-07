using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTask : MonoBehaviour
{

    public bool isComplete;
    public bool hazard;

    public Animator ani;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        isComplete = true;
        hazard = false;
        ani = gameObject.GetComponentInParent<Animator>();

    }

    // Update is called once per frame

    public void onPress(){ //executes when a button is clicked on by the player
        if (isComplete == false){ //if task is incomplete : mark complete, mark no hazard, execute the hazardhandlers hazard cleared method
            isComplete = true;
            hazard = false;
            FindAnyObjectByType<HazardHandler>().hazardCleared();
        }
        ani.SetTrigger("Pushed"); // play button animation
        ani.ResetTrigger("Released"); //^
        Invoke("onRelease", 0.5f); // delay allows animation to play once only before reseting 
    } 

    public void onRelease(){ // resets the animation for the buttons
        ani.SetTrigger("Released");
        ani.ResetTrigger("Pushed");
    }

    public void startTask(){ //called when the button is chosen for the current hazard
        hazard = true; // marks as active hazard
        isComplete = false; // marks as incomplete
        FindAnyObjectByType<AltitudeText>().errorRoom = gameObject.GetComponentInParent<Transform>().parent.parent.name;
        // ^ passes the current hazard room to AltitudeText
    }
}
