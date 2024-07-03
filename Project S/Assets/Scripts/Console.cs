using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Console : MonoBehaviour
{

    public void Start(){
        // outline = gameObject.GetComponent<Outline>(); get outline shader on gameobject
        // outline.enabled = false; set the ouline to false
    }
   //detects if the player looks at object
    public void OnLook(){

    }

    //detects if the player looks away from object
public void OnLookAway(){
    // outlines.enabled = false;
}

   //Detects if the player clicks object
    public void OnClickAction()
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }
}