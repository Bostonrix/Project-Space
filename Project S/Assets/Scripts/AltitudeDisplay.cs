using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeDisplay : MonoBehaviour
{

    public GameObject Environment;
    public string prefix = "Altitude: ";
    public float slideScale = 2f;
    private float offset_x;
    private float offset_z;
    private float offset_y;
    private float initalt;
    // Start is called before the first frame update
    void Start()
    {
        offset_x = this.transform.position.x;
        offset_y = this.transform.position.y;
        offset_z = this.transform.position.z;
        Environment.TryGetComponent<EnvironmentHandler>(out var env);
        initalt = env.Altitude;
    }

    // Update is called once per frame
    void Update()
    {
        Environment.TryGetComponent<EnvironmentHandler>(out var env);
        float alt = env.Altitude;
        this.transform.position = new Vector3(
            offset_x,
            offset_y + (slideScale * alt / initalt),
            offset_z
            );
    }
}
