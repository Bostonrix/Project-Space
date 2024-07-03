using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchGame : MonoBehaviour
{
    public GameObject ship;
    public GameObject beam;
    public GameObject target;

    private int shipMoveDirection = 0;
    private int targetMoveDirection = 0;
    private int shipDistance = 3;


    
    private double shipSpeed = 1.5; // PI Radians per second
    private double shipPosition = 0;
    private double targetSpeed = 2.0; // PI Radians per second
    private double targetTimer = 0; 
    private double targetPosition; // PI Radians
    private int researchScore = 0;
    private int targetState;
    private int state_IDLE = 0;
    private int state_MOVING = 1;


    // Start is called before the first frame update
    void Start()
    {
        targetState = state_IDLE;
        targetTimer = 3; // Seconds
    }

    // Update is called once per frame
    void Update()
    {
        shipMoveDirection = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shipMoveDirection -= 1;
        } 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            shipMoveDirection += 1;
        }
        shipPosition += shipMoveDirection * shipSpeed * Time.deltaTime;
        targetTimer -= Time.deltaTime;
        if (targetTimer <= 0)
        {
            if (targetState == state_IDLE)
            {
                targetState = state_MOVING;
                targetTimer = 2;

                if ((Random.Range(0f, 1f) > 0.5))
                {
                    targetMoveDirection = 1;
                } else
                {
                    targetMoveDirection = -1;
                }
           
            } else if (targetState == state_MOVING)
            {
                targetState = state_IDLE;
                targetTimer = 3;
                targetMoveDirection = 0;
            }
        }
        targetPosition += targetSpeed * targetMoveDirection * Time.deltaTime;

        
        ship.transform.position = new Vector3(shipDistance * Mathf.Sin((float)shipPosition), shipDistance * Mathf.Cos((float)shipPosition), 0f);
        ship.transform.rotation = Quaternion.Euler(0, 0,-90 * (float)shipPosition);
        target.transform.position = new Vector3(Mathf.Sin((float)targetPosition), Mathf.Cos((float)targetPosition), 0f);
        target.transform.rotation = Quaternion.Euler(0, 0,4 *  Mathf.PI * (float)targetPosition);
    }
}
