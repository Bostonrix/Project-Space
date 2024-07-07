using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardHandler : MonoBehaviour
{

    bool activeHazard;
    public float timebetweenHazards;
    ButtonTask[] buttonTasks;
    ButtonTask current;
    public AudioSource alarm;

    void Start()
    {
        buttonTasks = FindObjectsOfType<ButtonTask>(); //finds all 
        timebetweenHazards = Random.Range(10, 30);
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
        alarm.Pause();
        activeHazard = false;
        timebetweenHazards = Random.Range(20, 30);
        GetComponentInParent<EnvironmentHandler>().hazardCleared();
    }

    void beginHazard (){
        alarm.Play();
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
