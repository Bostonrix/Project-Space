using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHandler : MonoBehaviour
{
    public float setTimebetweenHazards = 60;
    bool activeHazard;
    public float timebetweenHazards;
    ButtonTask[] buttonTasks;
    void Start()
    {
        buttonTasks = FindObjectsOfType<ButtonTask>();
        timebetweenHazards = setTimebetweenHazards;
        activeHazard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeHazard == false){
            timebetweenHazards -= 1*Time.deltaTime;
            if (timebetweenHazards <= 0){
                beginHazard();
            }
        }
    }

    public void hazardCleared(){
        activeHazard = false;
        timebetweenHazards = setTimebetweenHazards;
        GetComponentInParent<EnvironmentHandler>().hazardCleared();
    }

    void beginHazard (){
        activeHazard = true;
        ButtonTask current = buttonTasks[Random.Range(0,buttonTasks.Length-1)]; // randomly selects detected task buttons (doesn't seem to be random at the moment)
        current.startTask(); //starts task on selected 
        GetComponentInParent<EnvironmentHandler>().disarray(); //sends environment into Disarray
    }
}
