using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTask : MonoBehaviour
{

    public bool isComplete;
    public bool hazard;

    // Start is called before the first frame update
    void Start()
    {
        isComplete = true;
        hazard = false;

    }

    // Update is called once per frame

    public void onPress(){
        isComplete = true;
        hazard = false;
        FindAnyObjectByType<HazardHandler>().hazardCleared();
    }

    public void startTask(){
        hazard = true;
        isComplete = false;
        print("Hazard Started - Button Task: " + gameObject.GetComponentInParent<Transform>().parent.name);
    }
}
