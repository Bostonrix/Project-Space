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

    public void onPress(){
        if (isComplete == false){
            isComplete = true;
            hazard = false;
            FindAnyObjectByType<HazardHandler>().hazardCleared();
        }
        ani.SetTrigger("Pushed");
        ani.ResetTrigger("Released");
        Invoke("onRelease", 0.5f);
    } 

    public void onRelease(){
        ani.SetTrigger("Released");
        ani.ResetTrigger("Pushed");
    }

    public void startTask(){
        hazard = true;
        isComplete = false;
        FindAnyObjectByType<AltitudeText>().errorRoom = gameObject.GetComponentInParent<Transform>().parent.parent.name;
        print("Hazard Started - Button Task: " + gameObject.GetComponentInParent<Transform>().parent.parent.name);
    }
}
