using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeMover : MonoBehaviour
{
    public GameObject Environment;
    private Vector3 offset;

    public float altitudeRealScale = 250f;
    private float startalt;
    
    // Start is called before the first frame update
    void Start()
    {
        Environment.TryGetComponent<EnvironmentHandler>(out var env);
        startalt = env.Altitude;
    }

    // Update is called once per frame
    void Update()
    {
        Environment.TryGetComponent<EnvironmentHandler>(out var env);
        float alt = env.Altitude;
        float newscale = altitudeRealScale * startalt / alt;
        this.transform.localScale = new Vector3(newscale,newscale,0);
    }
}
