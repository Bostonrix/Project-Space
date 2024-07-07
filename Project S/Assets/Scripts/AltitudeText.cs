using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeText : MonoBehaviour
{

    public TMP_Text distToCrit;
    public TMP_Text altitudeText;
    public TMP_Text research;
    public TMP_Text errorPlace;
    public GameObject env;
    public GameObject hazardState;
    public GameObject safeState;
    public Slider researchSlider;
    public Slider distSlider;

    
    EnvironmentHandler handler;
    HazardHandler hazardHandler;

    float researchScore;
    float researchGoal;
    float altitude;
    float distToCritical;
    bool inHazard;
    public string errorRoom;



    // Start is called before the first frame update
    void Start()
    {   

        handler = env.GetComponent<EnvironmentHandler>();
        hazardHandler = env.GetComponent<HazardHandler>();
        distSlider.minValue = 0; // sets slider min for the Distance to critical bar to 0 
        distSlider.maxValue = distToCritical = handler.Altitude - handler.criticalDistance; // sets slider min for the Distance to critical bar to teh max distance until critical distance
    }

    // Update is called once per frame
    void Update()
    {
        inHazard = handler.inDisarray; // check to see if the game is in a hazard state
        if (inHazard == false){ // if not in hazard state : control panel displays normal screen
            safeSceen();
        } else { // if in hazard state : display Error screen after 1 second
            Invoke ("hazardScreen", 1); //delay allows the hazard screen to get passed the error location
        }

    }

    void updateValues(){
        researchScore = handler.Research / researchGoal * 100; // converts research score to a percentage
        altitude = handler.Altitude;
        distToCritical = altitude - handler.criticalDistance;
    }

    void safeSceen() {
        safeState.SetActive(true); // shows the normal control panel screen
        hazardState.SetActive(false); // hides the Error screen
        researchGoal = handler.ResearchGoal;  
        updateValues();
        distToCrit.text = "Distance to Critical: " + distToCritical.ToString("F0") + "Km";
        if(distToCritical  < 50000) { distSlider.fillRect.gameObject.GetComponent<Image>().color =  Color.red;}
        distSlider.value = distToCritical;
        research.text = "Research Completed: " + researchScore.ToString("F0") + "%";
        researchSlider.value = researchScore;
        altitudeText.text = "Altitude: " + altitude.ToString("F0") + "Km";
    }

    void hazardScreen(){
        safeState.SetActive(false); // hides the normal control panel screen
        hazardState.SetActive(true); // shows the error screen
        errorPlace.text = "Error detected in: " + errorRoom;

    }
}
