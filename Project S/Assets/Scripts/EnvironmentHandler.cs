using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    public int Altitude;
    public float Research;
    public float ResearchCap;
    public int Fuel;
    private int Flag;
    private bool HazardFlag;

    // Start is called before the first frame update
    void Start()
    {
        Altitude = 20000;
        Research = 0f;
        ResearchCap = 60f;
        Fuel = 100;
        Flag = 1;
        HazardFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        AltitudeHandler();
        checkResearch();
    }



    // Controls altitude decline rate.
    void AltitudeHandler() {
        if (Flag == 1){
            if (Altitude >= 18000){
            Altitude -= 1;
            } else if (Altitude >= 15000){
                Altitude -= 5;
            }else if (Altitude >= 10000){
                    Altitude -= 20;
            }else if (Altitude >= 5000){
                Altitude -= 50;
            }else {
                Debug.Log("Game is Over");
                Flag = 0;
            }
        }
    }

    void checkResearch(){
        if(Research > ResearchCap){
            Debug.Log("Game Won Condition");
        }
    }
}
