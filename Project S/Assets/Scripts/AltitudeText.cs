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
    public GameObject env;
    public Slider researchSlider;
    public Slider distSlider;
    EnvironmentHandler handler;

    float researchScore;
    float researchGoal;
    float altitude;
    float distToCritical;
    bool inHazard;



    // Start is called before the first frame update
    void Start()
    {   

        handler = env.GetComponent<EnvironmentHandler>();
        distSlider.minValue = handler.criticalDistance;
        distSlider.maxValue = 60000
        ;
    }

    // Update is called once per frame
    void Update()
    {
        inHazard = handler.inDisarray;
        if (inHazard == false){
            safeSceen();
        } else {

        }

    }

    void updateValues(){
        researchScore = handler.Research / researchGoal * 100;
        altitude = handler.Altitude;
        distToCritical = altitude - handler.criticalDistance;
    }

    void safeSceen() {
        transform.Find("SafeState").gameObject.SetActive = true;
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

    }
}
