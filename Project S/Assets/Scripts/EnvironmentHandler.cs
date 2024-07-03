using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    public int Altitude;
    public int Fuel;
    private int Flag;

    // Start is called before the first frame update
    void Start()
    {
        Altitude = 20000;
        Fuel = 100;
        Flag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag == 1){
            if (Altitude >= 18000){
            Altitude -= 1;
            } else if (Altitude >= 15000){
                Altitude -= 5;
            }else if (Altitude >= 10000){
                    Altitude -= 20;
            }else if (Altitude >= 5000){
                Altitude -= 50;
            }else {
                Debug.Log("Game is Over");
                Flag = 0;
            }
        }
    }
}
