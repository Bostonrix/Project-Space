using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{

public GameObject env;
EnvironmentHandler envHand;
float score;
float goal;
Text myText;

    void Start()
    {
        envHand = env.GetComponent<EnvironmentHandler>();
        goal = envHand.ResearchGoal;

    }

    // Update is called once per frame
    void Update()
    {   
        score = envHand.Research;
        myText.text = "Research Collected: " + score + " / " + goal;
        
    }
}
