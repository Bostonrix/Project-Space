using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHandler : MonoBehaviour
{
    public float setTimebetweenHazards = 60;
    bool activeHazard;
    public float timebetweenHazards;
    ButtonTask[] buttonTasks;
    ButtonTask current;
    void Start()
    {
        buttonTasks = FindObjectsOfType<ButtonTask>(); //finds all 
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
        FindAnyObjectByType<PlayerController>().canMove = true;
        activeHazard = true;
        current = buttonTasks[Random.Range(0,buttonTasks.Length-1)]; // randomly selects detected task buttons
        current.startTask(); //starts task on selected 
        GetComponentInParent<EnvironmentHandler>().disarray(); //sends environment into Disarray
    }

    public ButtonTask getCurrent(){
        return current;
    }
}
