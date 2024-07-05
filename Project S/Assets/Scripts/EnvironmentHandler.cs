using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentHandler : MonoBehaviour
{
    public float Altitude;
    public float altitudeLossRate = 100; //variable to dynamically change altitude drop rate
    public float Research = 0;
    public float ResearchGoal = 100;
    public int Fuel;
    private int Flag;
    public float criticalDistance = 5000;
    public float safeAltitude;

    // Start is called before the first frame update
    void Start()
    {
        Altitude = 60000;
        Fuel = 100;
        Flag = 1;
        Research = 0;
        ResearchGoal = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("AltitudeHandler", 1);
        
        if(Research >= ResearchGoal){
            Debug.Log("Won");
            SceneManager.LoadScene("WinCase");
        }
       
    }



    // Controls altitude decline rate.
    void AltitudeHandler() {
        if (Flag == 1){
            if (Altitude >= 18000){
            Altitude -= 1 * Time.deltaTime *altitudeLossRate;
            } else if (Altitude >= 15000){
                Altitude -= 5 * Time.deltaTime * altitudeLossRate;
            }else if (Altitude >= 10000){
                    Altitude -= 20 * Time.deltaTime * altitudeLossRate;
            }else if (Altitude >= criticalDistance){
                Altitude -= 50 * Time.deltaTime * altitudeLossRate;
            }else {
                Debug.Log("Game is Over");
                SceneManager.LoadScene("FailCase");
                Flag = 0;
            }
        }
    }

}
