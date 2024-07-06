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
        distSlider.minValue = handler.criticalDistance;
        distSlider.maxValue = 60000;
    }

    // Update is called once per frame
    void Update()
    {
        inHazard = handler.inDisarray;
        if (inHazard == false){
            safeSceen();
        } else {
            Invoke ("hazardScreen", 1);
        }

    }

    void updateValues(){
        researchScore = handler.Research / researchGoal * 100;
        altitude = handler.Altitude;
        distToCritical = altitude - handler.criticalDistance;
    }

    void safeSceen() {
        safeState.SetActive(true);
        hazardState.SetActive(false);
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
        safeState.SetActive(false);
        hazardState.SetActive(true);
        errorPlace.text = "Error detected in: " + errorRoom;

    }
}
