using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAltitudeHandler : MonoBehaviour
{
    //class hides and shows research panel base on the altitude of the ship
    // public GameObject environment;
    private EnvironmentHandler environmentHandler;
    public Transform researchPanel;


    // Start is called before the first frame update
    void Start()
    {

        // environmentHandler = environment.GetComponent<EnvironmentHandler>();
        environmentHandler = GameObject.FindAnyObjectByType<EnvironmentHandler>();
        researchPanel = transform.Find("ResearchPanel");

        
    }

    // Update is called once per frame
    void Update()
    {
         if (environmentHandler.Altitude <= environmentHandler.safeAltitudeMax && environmentHandler.Altitude >= environmentHandler.safeAltitudeMin){
             researchPanel.gameObject.SetActive(true);
         } else {
            researchPanel.gameObject.SetActive(false);
         }
    }
}
