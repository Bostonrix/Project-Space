using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
// using UnityEditor.Animations;
// using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class Console : MonoBehaviour
{
    Animator ani;
    bool triggered = false;
    public void Start(){
        // outline = gameObject.GetComponent<Outline>(); get outline shader on gameobject
        // outline.enabled = false; set the ouline to false
        ani = gameObject.GetComponentInParent<Animator>();
    }
   //detects if the player looks at object
    public void OnLook(){

    }

    //detects if the player looks away from object
public void OnLookAway(){
    // outlines.enabled = false;
}

   //Detects if the player clicks object
    public void buttonPressed()
    {
        triggered = true;
        if(triggered == true)
        {
            ani.SetTrigger("Pushed");
        } //plays buttonpressed animation

    }

    public void buttonReleased(){
        triggered = false;
        if (triggered == false)
        {
            ani.SetTrigger("Released");//resets trigger and stop the button animation
        }
    }
}