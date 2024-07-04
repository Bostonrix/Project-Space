using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{

public GameObject researchGame;
private float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        researchGame.TryGetComponent<ResearchGame>(out var scoreHolder);
        score = scoreHolder.getScore();
    }
}
