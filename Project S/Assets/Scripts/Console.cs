using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class Console : MonoBehaviour
{
    Animator ani;
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
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        ani.SetTrigger("Pushed");

    }

    public void buttonReleased(){
        ani.ResetTrigger("Pushed");
    }
}