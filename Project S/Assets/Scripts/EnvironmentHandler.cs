using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentHandler : MonoBehaviour
{
    public float Altitude;
    public float altitudeLossRate = 100; //variable to dynamically change altitude drop rate
    public float Research = 0;
    public float ResearchGoal = 20;
    public int Fuel;
    private int Flag;
    public float criticalDistance = 5000;
    public float safeAltitudeMin;
    public float safeAltitudeMax;
    public bool inDisarray;
    public SafeAltitudeHandler researchPanel;

    // Start is called before the first frame update
    void Start()
    {
        Altitude = 35000;
        Fuel = 100;
        Flag = 1;
        Research = 0;
        ResearchGoal = 30;
        safeAltitudeMin = 25000;
        safeAltitudeMax = 35000;
        altitudeLossRate = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("AltitudeHandler", 1);
        
        if(Research >= ResearchGoal){ // player reaches the researchGoal : scene changes to win case
            Debug.Log("Won");
            SceneManager.LoadScene("WinCase");
        }
       
    }



    // Controls altitude decline rate.
    void AltitudeHandler() {
        if (Flag == 1){
            if (Altitude >= 30000){
            Altitude -= 1 * Time.deltaTime *altitudeLossRate;
            } else if (Altitude >= 20000){
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

    
    public void disarray(){ //called by HazardHandler when a hazard is started
        inDisarray = true;
        FindFirstObjectByType<FuelLever>().active = false; // finds the FuelLever and disables it
        researchPanel.gameObject.SetActive(false); // disables the ResearchPanel
    }

    public void hazardCleared(){ //called by HazardHandler when a hazard is cleared
        inDisarray = false;
        FindFirstObjectByType<FuelLever>().active = true; // finds the FuelLever and activates it
        if (researchPanel.gameObject){
        researchPanel.gameObject.SetActive(true); // if the game can find the research panel : it activates it
        }
    }

}
