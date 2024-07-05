using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeText : MonoBehaviour
{

    public TextMesh distToCrit;
    public TextMesh research;
    public GameObject env;
    EnvironmentHandler handler;

    float researchScore;
    float ResearchGoal;
    float altitude;
    float distToCritical;



    // Start is called before the first frame update
    void Start()
    {
        handler = env.GetComponent<EnvironmentHandler>();
        ResearchGoal = handler.ResearchGoal;
    }

    // Update is called once per frame
    void Update()
    {
        updateValues();
        distToCrit.text = "Distance to Critical: " ;
    }

    void updateValues(){
        researchScore = handler.Research;
        altitude = handler.Altitude;
        distToCritical = altitude - handler.criticalDistance;
    }
}
