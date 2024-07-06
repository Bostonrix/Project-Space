using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHandler : MonoBehaviour
{
    public float setTimebetweenHazards = 60;
    public float timebetweenHazards;
    ButtonTask[] buttonTasks;
    void Start()
    {
        buttonTasks = FindObjectsOfType<ButtonTask>();
        timebetweenHazards = setTimebetweenHazards;
    }

    // Update is called once per frame
    void Update()
    {
        timebetweenHazards -= 1*Time.deltaTime;
        if (timebetweenHazards <= 0){
            beginHazard();
        }
    }

    public void hazardCleared(){
        timebetweenHazards = setTimebetweenHazards;
        GetComponentInParent<EnvironmentHandler>().hazardCleared();
    }

    void beginHazard (){
        ButtonTask current = buttonTasks[Random.Range(0,buttonTasks.Length-1)]; // randomly selects detected task buttons
        current.startTask(); //starts task on selected 
        GetComponentInParent<EnvironmentHandler>().disarray(); //sends environment into Disarray
    }
}
