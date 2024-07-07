using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FuelLever : MonoBehaviour
{
    Animator ani;
    bool triggered = false;
    public bool active = true;
    public GameObject Environment;


    public void Start(){
        // outline = gameObject.GetComponent<Outline>(); get outline shader on gameobject
        // outline.enabled = false; set the ouline to false
        ani = gameObject.GetComponentInParent<Animator>();
    }


    void Update(){
        if(triggered == true){
            Environment.TryGetComponent<EnvironmentHandler>(out var newVar);
            newVar.Altitude += 20 * Time.deltaTime * newVar.altitudeLossRate;
        }
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
        if (active == true){
            triggered = !triggered;
            if(triggered == true)
            {
                ani.SetTrigger("Pushed");//activates Pushed trigger
                ani.ResetTrigger("Released"); // resets Released trigger
            } else if (triggered == false)
            {
                ani.SetTrigger("Released");// activates Released trigger
                ani.ResetTrigger("Pushed");// resets Pushed trigger
            }
        }
    }
}