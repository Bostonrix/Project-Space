using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAltitudeHandler : MonoBehaviour
{

    // public GameObject environment;
    private EnvironmentHandler environmentHandler;


    // Start is called before the first frame update
    void Start()
    {

        // environmentHandler = environment.GetComponent<EnvironmentHandler>();
        environmentHandler = GameObject.FindAnyObjectByType<EnvironmentHandler>();

        
    }

    // Update is called once per frame
    void Update()
    {
         if (environmentHandler.Altitude < environmentHandler.safeAltitudeMax && environmentHandler.Altitude > environmentHandler.safeAltitudeMin){
            gameObject.SetActive(true);
         } else {
            gameObject.SetActive(false);
         }
    }
}
