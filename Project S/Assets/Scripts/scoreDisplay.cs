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
        
    }
}
