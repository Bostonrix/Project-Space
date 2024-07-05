using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeText : MonoBehaviour
{

    public TMP_Text distToCrit;
    public TMP_Text research;
    public GameObject env;
    public Slider researchSlider;
    public Slider distSlider;
    EnvironmentHandler handler;

    float researchScore;
    float researchGoal;
    float altitude;
    float distToCritical;



    // Start is called before the first frame update
    void Start()
    {
        handler = env.GetComponent<EnvironmentHandler>();
        researchGoal = handler.ResearchGoal;
        distSlider.minValue = handler.criticalDistance;
        distSlider.maxValue = 60000
        ;
    }

    // Update is called once per frame
    void Update()
    {
        updateValues();
        distToCrit.text = "Distance to Critical: " + distToCritical.ToString("F0") + "Km";
        distToCrit.fontSize = 4;
        distSlider.value = altitude;
        research.text = "Research Completed: " + researchScore.ToString("F0") + "%";
        research.fontSize = 4;
        researchSlider.value = researchScore;

    }

    void updateValues(){
        researchScore = handler.Research / researchGoal * 100;
        altitude = handler.Altitude;
        distToCritical = altitude - handler.criticalDistance;
    }
}
