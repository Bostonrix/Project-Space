using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{

public GameObject env;
EnvironmentHandler envHand;
float score;
float goal;
 public TMP_Text myText;
 public TMP_Text safeAltitude;

    void Start()
    {
        envHand = env.GetComponent<EnvironmentHandler>();
        

    }

    // Update is called once per frame
    void Update()
    {   
        goal = envHand.ResearchGoal;
        score = envHand.Research;
        myText.fontSize = 0.05f;
        myText.text = "Research Collected: " + score/goal*100 + " %";
        safeAltitude.text = "Altitude range where research is possible: " + envHand.safeAltitudeMax.ToString("F0") + "Km to " + envHand.safeAltitudeMin.ToString("F0") + "Km";
        
    }
}
